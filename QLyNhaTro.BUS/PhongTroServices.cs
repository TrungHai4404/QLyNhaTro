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
            return db.PhongTroes.Where(x => x.MaLoaiPhong == id && x.TrangThai.Contains("Đang Thuê")).ToList();
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
    }
}
