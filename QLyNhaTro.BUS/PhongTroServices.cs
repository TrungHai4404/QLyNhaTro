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
            return db.PhongTroes.Where(x => x.MaLoaiPhong == id && x.TrangThai == "Trống").ToList();
        }
        // Lấy Khách thuê theo mã phòng
        public List<KhachThue> LayKhachThueTheoMaPhong(string id)
        {
            return db.KhachThues.Where(x => x.MaPhong == id).ToList();
        }

        //Lấy thông tin phòng trống theo mã phòng
        public PhongTro LayPhongTroTheoMaPhong(string maPhong)
        {
            return db.PhongTroes.SingleOrDefault(x => x.MaPhong == maPhong);
        }
        //Lấy số lượng phòng đã thuê
        public int SoLuongPhongDaThue()
        {
            return db.PhongTroes.Where(x => x.TrangThai.Contains("Đang Thuê")).Count();
        }
        //Lấy số lượng phòng trống
        public int SoLuongPhongTrong()
        {
            return db.PhongTroes.Where(x => x.TrangThai == "Trống").Count();
        }
    }
}
