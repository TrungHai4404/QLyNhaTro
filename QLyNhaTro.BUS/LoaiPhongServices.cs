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
        QLNTModel db = new QLNTModel();
        public List<LoaiPhong> GetAll()
        {
            return db.LoaiPhongs.ToList();
        }
        

    }
}
