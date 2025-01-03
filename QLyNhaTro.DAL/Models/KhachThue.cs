namespace QLyNhaTro.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachThue")]
    public partial class KhachThue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachThue()
        {
            HopDongs = new HashSet<HopDong>();
        }

        [Key]
        [StringLength(20)]
        public string MaKhachThue { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(20)]
        public string CMND_CCCD { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(200)]
        public string DiaChiThuongTru { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDauThue { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        [StringLength(20)]
        public string MaPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }

        public virtual PhongTro PhongTro { get; set; }
    }
}
