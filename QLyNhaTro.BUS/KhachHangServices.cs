using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro.BUS
{
    public class KhachHangServices
    {
        QLNTmodel db = new QLNTmodel();
        public List<KhachThue> GetAll()
        {
            return db.KhachThues.ToList();
        }
        
    }
}
