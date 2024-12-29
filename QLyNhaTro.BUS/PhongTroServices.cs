using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
   
    public class PhongTroServices
    {
        readonly KhachHangServices khachHangServices = new KhachHangServices();
        QLNTmodel db = new  QLNTmodel();

        

        public List<PhongTro> GetAll()
        {
            return db.PhongTroes.ToList();
        }
        //Lấy số phòng có khách thuê theo mã loại phòng
        public List<PhongTro> LayPhongTroCoKhachThueTheoLoaiPhong(string id)
        {
            return db.PhongTroes.Where(x => x.MaLoaiPhong == id && x.TrangThai.Contains("ang")).ToList();
        }
        // Lấy số phòng trống theo mã loại phòng
        public List<PhongTro> LayPhongTroTrongTheoLoaiPhong(string id)
        {
            return db.PhongTroes.Where(x => x.MaLoaiPhong == id && x.TrangThai.Contains("Tr")).ToList();
        }
        //Lấy thông tin phòng trống theo mã phòng
        public PhongTro LayPhongTroTheoMaPhong(string maPhong)
        {
            return db.PhongTroes.SingleOrDefault(x => x.MaPhong == maPhong);
        }
        //Lấy số lượng phòng đã thuê
        public int SoLuongPhongDaThue()
        {
            return db.PhongTroes.Count(x => x.TrangThai.Contains("ang"));
        }
        //Lấy số lượng phòng trống
        public int SoLuongPhongTrong()
        {
            return db.PhongTroes.Where(x => x.TrangThai == "Trống").Count();
        }
        // Lấy danh sách phòng trọ còn đủ sức chứa theo mã loại phòng
        public List<PhongTro> LayPhongTroConSucChuaTheoMaLoaiPhong(string maLoaiPhong)
        {
            // Truy vấn danh sách phòng theo loại phòng và kiểm tra sức chứa
            return db.PhongTroes
                     .Where(x => x.MaLoaiPhong == maLoaiPhong && // Kiểm tra loại phòng
                                 x.SucChua > db.KhachThues.Count(k => k.MaPhong == x.MaPhong)) // Phòng còn đủ chỗ
                     .ToList();
        }

        // Cập nhật tình trạng phòng
        public void CapNhatTinhTrangPhong(string selectedSoPhong, string v)
        {
            var phong = db.PhongTroes.SingleOrDefault(x => x.MaPhong == selectedSoPhong);
            if (phong != null)
            {
                phong.TrangThai = v;
                db.SaveChanges();
            }
        }
        // Kiểm tra phòng còn khách thuê không
        public int KiemTraPhongConKhachThueKhong(string maPhong)
        {
            return db.KhachThues.Count(x => x.MaPhong == maPhong);// 0 la k con khach
        }

        public List<PhongTro> LayPhongTroTheoLoaiPhong(string loaiPhong)
        {
            return db.PhongTroes.Where(x => x.MaLoaiPhong == loaiPhong).ToList();
        }
        // Lấy số lượng khách thuê theo mã phòng
        public int DemSoLuongKhachThueTheoMaPhong(string maPhong)
        {
            return db.KhachThues.Count(x => x.MaPhong == maPhong);
        }
        // Lấy mã hợp đồng theo mã phòng
        public string LayMaHopDongTheoMaPhong(string maPhong)
        {
            var hopDong = db.HopDongs.FirstOrDefault(x => x.MaPhong == maPhong);
            if (hopDong != null)
            {
                return hopDong.MaHopDong;
            }
            return null;
        }
        // Viết hàm tạo mã phòng tự động theo cấu trúc Pxx trong đó xx là số thứ tự
        public string TaoMaPhong()
        {
            // Lấy danh sách các mã phòng hiện có từ cơ sở dữ liệu
            var dsMaPhong = db.PhongTroes.Select(x => x.MaPhong).ToList();

            // Kiểm tra nếu chưa có mã nào thì trả về mã đầu tiên
            if (dsMaPhong == null || dsMaPhong.Count == 0)
            {
                return "P01";
            }

            // Lọc và lấy phần số từ danh sách mã phòng
            var danhSachSoThuTu = dsMaPhong
                .Where(ma => ma.StartsWith("P")) // Chỉ lấy các mã bắt đầu bằng "P"
                .Select(ma =>
                {
                    // Cắt bỏ tiền tố "P" để lấy phần số
                    if (int.TryParse(ma.Substring(1), out int so))
                    {
                        return so;
                    }
                    return 0; // Nếu không parse được, mặc định là 0
                })
                .OrderBy(so => so) // Sắp xếp danh sách theo thứ tự tăng dần
                .ToList();

            // Tìm số thứ tự nhỏ nhất còn thiếu
            int soThuTuMoi = 1; // Bắt đầu từ 1
            foreach (var so in danhSachSoThuTu)
            {
                if (soThuTuMoi < so) // Nếu tìm thấy khoảng trống
                {
                    break;
                }
                soThuTuMoi++;
            }

            // Tạo mã phòng mới (đảm bảo định dạng 2 chữ số)
            return "P" + soThuTuMoi.ToString("D2");
        }
        // Thêm phòng trọ   
        public void ThemPhongTro(PhongTro phongTro)
        {
            db.PhongTroes.Add(phongTro);
            db.SaveChanges();
        }

        public void XoaPhongTro(string maPhong)
        {
            db.PhongTroes.Remove(db.PhongTroes.FirstOrDefault(x => x.MaPhong == maPhong));
            db.SaveChanges();
        }
    }
}
