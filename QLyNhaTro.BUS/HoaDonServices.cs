using System;
using System.Collections.Generic;
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
        public void XoaHoaDon(string maHD)
        {
            var hd = db.HoaDons.FirstOrDefault(x => x.MaHopDong == maHD);
            if (hd != null)
            {
                db.HoaDons.Remove(hd);
                db.SaveChanges();
            }
        }
    }
}
