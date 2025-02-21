﻿using System;
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
        // Thêm loại phòng
        public void ThemLoaiPhong(LoaiPhong loaiPhong)
        {
            db.LoaiPhongs.Add(loaiPhong);
            db.SaveChanges();
        }
        // Kiểm tra loại phòng (0: LP01 - Phòng đơn, 1: LP02 - Phòng đôi)
        public int KiemTraLoaiPhong(string maLP)
        {
            return maLP == "LP01" ? 0 : 1;
        }
        public decimal LayGiaPhongTheoMaLoaiPhong(string text)
        {
            return db.LoaiPhongs.Where(x => x.MaLoaiPhong == text).Select(x => x.GiaCoBan).FirstOrDefault();
        }
    }
}
