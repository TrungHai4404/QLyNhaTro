namespace QLyNhaTro.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHopDong { get; set; }

        [Required]
        [StringLength(10)]
        public string ThangNam { get; set; }

        public decimal TienPhong { get; set; }

        public decimal? TienDichVu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TongTien { get; set; }

        [StringLength(20)]
        public string TrangThaiThanhToan { get; set; }

        public virtual HopDong HopDong { get; set; }
    }
}
