using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLyNhaTro_project
{
    internal class rptHoaDon
    {
        // Ma hoa don
        public string maHD { get; set; }
        public string maPhong { get; set; }
        public string maHopDong { get; set; }
        // gia tien
        public string tienPhong { get; set; }
        public string tienDien { get; set; }
        public string soDienCu { get; set; } // So dien cu
        public string soDienMoi { get; set; } // So dien moi
        public string tienNuoc { get; set; }
        public string soNuocCu { get; set; } // So nuoc cu
        public string soNuocMoi { get; set; } // So nuoc moi
        public string tienIntenet { get; set; }
        public string tienVeSinh { get; set; }
        public string tienBaoTri { get; set; }

        // Thanh tien
        public string thanhTienPhong { get; set; }
        public string thanhTienDien { get; set; }
        public string thanhTienNuoc { get; set; }
        public string thanhTienInternet { get; set; }
        public string thanhTienVeSinh { get; set; }
        public string thanhTienBaoTri { get; set; }
        public string tongTien { get; set; }

        // bang gia dich vu
        public string giaDien { get; set; }
        public string giaNuoc { get; set; }
        public string giaInternet { get; set; }
        public string giaVeSinh { get; set; }
        public string giaBaoTri { get; set; }
    }
}
