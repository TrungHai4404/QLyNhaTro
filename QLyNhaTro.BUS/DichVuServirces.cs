using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
    public class DichVuServirces
    {
        QLNTmodel db = new QLNTmodel();
        public decimal TienDien(string maDV)
        {
            return db.DichVus.SingleOrDefault(x => x.MaDichVu == maDV).DonGia;
        }
        public decimal TienNuoc(string maDV)
        {
            return db.DichVus.SingleOrDefault(x => x.MaDichVu == maDV).DonGia;
        }
        public decimal TienInternet(string maDV)
        {
            return db.DichVus.SingleOrDefault(x => x.MaDichVu == maDV).DonGia;
        }

    }
}
