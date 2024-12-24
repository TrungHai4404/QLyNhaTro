namespace QLyNhaTro.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDichVu")]
    public partial class ChiTietDichVu
    {
        [Key]
        [StringLength(20)]
        public string MaChiTietDichVu { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        [Required]
        [StringLength(20)]
        public string MaDichVu { get; set; }

        public decimal SoLuong { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
