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
        // Lấy giá tiền theo mã dịch vụ
        public decimal GiaTienDichVu(string maDV)
        {
            return db.DichVus.SingleOrDefault(x => x.MaDichVu == maDV).DonGia;
        }
        

    }
}
