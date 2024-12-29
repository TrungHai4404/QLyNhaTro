using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
    public class KhachHangServices
    {
        QLNTmodel db = new QLNTmodel();

        public KhachThue FindByID(string maKH)
        {
            return db.KhachThues.FirstOrDefault(x => x.MaKhachThue == maKH); 
        }

        public List<KhachThue> GetAll()
        {
            return db.KhachThues.ToList();
        }
        // Lấy Khách thuê theo mã phòng
        public List<KhachThue> LayKhachThueTheoMaPhong(string id)
        {
            return db.KhachThues.Where(x => x.MaPhong == id).ToList();
        }
        
        // Đếm số lượng khách thuê trong một phòng
        public int DemSLKhach(string maPhong)
        {
            return db.KhachThues.Count(x => x.MaPhong == maPhong);
        }

        // Thêm khách thuê
        public void ThemKhachThue(KhachThue khachThue)
        {
            db.KhachThues.Add(khachThue);
            db.SaveChanges();
        }

        public string TaoMaKhachThue()
        {
            // Lấy danh sách các mã khách thuê hiện có từ cơ sở dữ liệu
            var dsMaKhachThue = db.KhachThues.Select(x => x.MaKhachThue).ToList();

            // Kiểm tra nếu chưa có mã nào thì trả về mã đầu tiên
            if (dsMaKhachThue == null || dsMaKhachThue.Count == 0)
            {
                return "KT01";
            }

            // Lọc và lấy phần số từ danh sách mã khách thuê
            var danhSachSoThuTu = dsMaKhachThue
                .Where(ma => ma.StartsWith("KT")) // Chỉ lấy các mã bắt đầu bằng "KT"
                .Select(ma =>
                {
                    // Cắt bỏ tiền tố "KT" để lấy phần số
                    if (int.TryParse(ma.Substring(2), out int so))
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

            // Tạo mã khách thuê mới (đảm bảo định dạng 2 chữ số)
            return "KT" + soThuTuMoi.ToString("D2");
        }


        public void CapNhatKhachThue(KhachThue khachHang)
        {
            db.KhachThues.AddOrUpdate(khachHang);
            db.SaveChanges();
        }

        public void XoaKhachThue(string maKH)
        {
            var khachThue = db.KhachThues.FirstOrDefault(x => x.MaKhachThue == maKH);
            if (khachThue != null)
            {
                db.KhachThues.Remove(khachThue);
                db.SaveChanges();
            }
            
        }
    }
}
