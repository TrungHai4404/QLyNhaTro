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
        QLNTModel db = new QLNTModel();
        public List<KhachThue> LayKhachThueTheoMaPhong(string maPhong)
        {
            return db.HopDongs.Where(x => x.MaPhong == maPhong).Select(x => x.KhachThue).ToList();
        }
    }
}
