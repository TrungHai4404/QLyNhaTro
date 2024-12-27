using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
    public class LoaiPhongServices
    {
        QLNTmodel db = new QLNTmodel();
        public List<LoaiPhong> GetAll()
        {
            return db.LoaiPhongs.ToList();
        }
        // Kiểm tra loại phòng (0: LP01 - Phòng đơn, 1: LP02 - Phòng đôi)
        public int KiemTraLoaiPhong(string maLP)
        {
            return maLP == "LP01" ? 0 : 1;
        }



    }
}
