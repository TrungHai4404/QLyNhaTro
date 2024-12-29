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
            return db.DichVus.Where(x => x.MaDichVu == maDV).Select(x => x.DonGia).SingleOrDefault();
        }
        //Lấy ds dịch vụ
        public List<DichVu> GetAll()
        {
            return db.DichVus.ToList();
        }
        // Cập nhật dịch vụ
        public void CapNhatDichVu(DichVu dichVu)
        {
            var dv = db.DichVus.SingleOrDefault(x => x.MaDichVu == dichVu.MaDichVu);
            dv.TenDichVu = dichVu.TenDichVu;
            dv.DonGia = dichVu.DonGia;
            db.SaveChanges();
        }


    }
}
