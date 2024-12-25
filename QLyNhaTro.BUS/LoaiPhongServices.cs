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
        

    }
}
