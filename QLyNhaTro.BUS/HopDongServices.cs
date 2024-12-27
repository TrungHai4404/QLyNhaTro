using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
    public class HopDongServices
    {
        QLNTmodel db = new QLNTmodel();
        // lấy danh sách  hợp đồng
        public List<HopDong> GetAll()
        {
            return db.HopDongs.ToList();
        }
        // Tìm Hợp đồng theo mã khách hàng
        public HopDong FindByID(string maKH)
        {
            return db.HopDongs.FirstOrDefault(x => x.MaKhachThue == maKH);
        }
        // Hàm tạo mã hợp đông
        public string TaoMaHopDong()
        {
            // Lấy danh sách các mã hợp đồng hiện có từ cơ sở dữ liệu
            var dsMaHopDong = db.HopDongs.Select(x => x.MaHopDong).ToList();

            // Kiểm tra nếu chưa có mã nào thì trả về mã đầu tiên
            if (dsMaHopDong == null || dsMaHopDong.Count == 0)
            {
                return "HD01";
            }

            // Lọc và lấy phần số từ danh sách mã hợp đồng
            var danhSachSoThuTu = dsMaHopDong
                .Where(ma => ma.StartsWith("HD")) // Chỉ lấy các mã bắt đầu bằng "HD"
                .Select(ma =>
                {
                    // Cắt bỏ tiền tố "HD" để lấy phần số
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

            // Tạo mã hợp đồng mới (đảm bảo định dạng 2 chữ số)
            return "HD" + soThuTuMoi.ToString("D2");
        }
        public void ThemHopDong(HopDong hopDong)
        {
            db.HopDongs.Add(hopDong);
            db.SaveChanges();
        }
        // Hàm cập nhật hợp đồng
        public void CapNhatHopDong(string maHopDong, DateTime? ngayBatDauThue)
        {
            var hopDong = db.HopDongs.SingleOrDefault(x => x.MaHopDong == maHopDong);
            if (hopDong != null)
            {
                hopDong.NgayKyHopDong = ngayBatDauThue;
                hopDong.NgayKetThuc = ngayBatDauThue.Value.AddMonths(6);
                db.SaveChanges();
            }
        }

       

        public void XoaHopDong(string maKH)
        {
            db.HopDongs.Remove(db.HopDongs.FirstOrDefault(x => x.MaKhachThue == maKH));
            db.SaveChanges();
        }
    }
}
