using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
   
    public class PhongTroServices
    {
        QLNTModel db = new  QLNTModel();

        

        public List<PhongTro> GetAll()
        {
            return db.PhongTroes.ToList();
        }
        // Lấy số phòng theo loại phòng
        public List<PhongTro> GetPhongTroByLoaiPhong(string id)
        {
            return db.PhongTroes.Where(x => x.MaLoaiPhong == id).ToList();
        }

        // Lấy số phòng đã được thuê
        public List<PhongTro> PhongDaDuocThue()
        {
            return db.PhongTroes.Where(p => p.TrangThai == "Đã Thuê").ToList();
        }
        // Lấy số phòng trống
        public List<PhongTro> PhongTrong()
        {
            return db.PhongTroes.Where(p => p.TrangThai == "Trống").ToList();
        }

    }
}
