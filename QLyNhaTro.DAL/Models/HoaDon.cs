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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietDichVus = new HashSet<ChiTietDichVu>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        public int MaHopDong { get; set; }

        [Required]
        [StringLength(10)]
        public string ThangNam { get; set; }

        public decimal TienPhong { get; set; }

        public decimal? TienDichVu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TongTien { get; set; }

        [StringLength(20)]
        public string TrangThaiThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; }

        public virtual HopDong HopDong { get; set; }
    }
}
