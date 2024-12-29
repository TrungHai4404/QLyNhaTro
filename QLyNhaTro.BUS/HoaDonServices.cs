using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
    public class HoaDonServices
    {
        QLNTmodel db = new QLNTmodel();
        public HoaDon LayHoaDonTheoHopDong(string maHD)
        {
            return db.HoaDons.FirstOrDefault(x => x.MaHopDong == maHD);
        }
        // lấy hóa đơn theo mã hóa đơn
        public HoaDon LayHoaDonTheoMaHoaDon(string maHD)
        {
            return db.HoaDons.FirstOrDefault(x => x.MaHoaDon == maHD);
        }

        // lấy danh sách hóa đơn
        public List<HoaDon> GetAllHoaDon()
        {
            return db.HoaDons.ToList();
        }
        // Lấy danh sách mã hóa đơn
        public List<string> LayDanhSachMaHoaDon()
        {
            return db.HoaDons.Select(x => x.MaHoaDon).ToList();
        }
        //Thêm hóa đơn
        public void ThemHoaDon(HoaDon hd)
        {
            db.HoaDons.Add(hd);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw;
            }
            db.SaveChanges();
        }
        // Xóa hóa đơn có trạng thái là Đã thanh toán
        public void XoaHoaDonDaThanhToan(string trangThai)
        {
            var danhSachHoaDon = db.HoaDons.Where(x => x.TrangThaiThanhToan == trangThai).ToList();
            foreach (var item in danhSachHoaDon)
            {
                db.HoaDons.Remove(item);
            }
            db.SaveChanges();
        }

        // Tạo mã hóa đơn tự động
        public string TaoMaHoaDon(string maHopDong, List<string> danhSachHoaDon)
        {
            // Tìm tất cả hóa đơn liên quan đến hợp đồng
            var hoaDonLienQuan = danhSachHoaDon
                .Where(hoaDon => hoaDon.StartsWith(maHopDong + "_"))
                .ToList();

            // Danh sách số thứ tự của các hóa đơn đã tồn tại
            List<int> danhSachSoThuTu = new List<int>();

            foreach (var hoaDon in hoaDonLienQuan)
            {
                // Tách số thứ tự từ mã hóa đơn (VD: HD01_05 -> 05)
                var phanSoThuTu = hoaDon.Substring(maHopDong.Length + 1);
                if (int.TryParse(phanSoThuTu, out int soThuTu))
                {
                    danhSachSoThuTu.Add(soThuTu);
                }
            }

            // Sắp xếp danh sách số thứ tự theo thứ tự tăng dần
            danhSachSoThuTu.Sort();

            // Tìm số thứ tự nhỏ nhất bị thiếu
            int soThuTuMoi = 1; // Bắt đầu từ 1
            foreach (var soThuTu in danhSachSoThuTu)
            {
                if (soThuTu == soThuTuMoi)
                {
                    soThuTuMoi++; // Nếu số hiện tại đã tồn tại, tăng lên 1
                }
                else
                {
                    break; // Nếu gặp số thiếu, thoát vòng lặp
                }
            }

            // Tạo mã hóa đơn mới (VD: HD01_03)
            string maHoaDonMoi = $"{maHopDong}_{soThuTuMoi:D2}";

            return maHoaDonMoi;
        }


        public void XoaHoaDon(string maHD) // Xóa hóa đơn theo mã hợp đồng
        {
            var hd = db.HoaDons.FirstOrDefault(x => x.MaHopDong == maHD);
            if (hd != null)
            {
                db.HoaDons.Remove(hd);
                db.SaveChanges();
            }
        }
        //Lấy danh sách hóa đơn theo mã hợp đồng
        public List<HoaDon> LayDSHoaDonTheoMaHopDong(string maHopDong)
        {
            return db.HoaDons.Where(x => x.MaHopDong == maHopDong).ToList();
        }
        
        public void CapNhatHoaDon(HoaDon hoaDon)
        {
            hoaDon.TrangThaiThanhToan = "Đã thanh toán";
            db.SaveChanges();
        }
    }
}
