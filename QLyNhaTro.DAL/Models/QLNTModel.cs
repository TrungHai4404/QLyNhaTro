using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLyNhaTro.DAL.Models
{
    public partial class QLNTmodel : DbContext
    {
        public QLNTmodel()
            : base("name=QLNTmodel")
        {
        }

        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachThue> KhachThues { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<PhongTro> PhongTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.PhongTroes)
                .WithMany(e => e.DichVus)
                .Map(m => m.ToTable("ChiTietDichVu").MapLeftKey("MaDichVu").MapRightKey("MaPhong"));

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 2);

            modelBuilder.Entity<HopDong>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.HopDong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachThue>()
                .HasMany(e => e.HopDongs)
                .WithRequired(e => e.KhachThue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.DienTich)
                .HasPrecision(10, 2);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.PhongTroes)
                .WithRequired(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongTro>()
                .HasMany(e => e.HopDongs)
                .WithRequired(e => e.PhongTro)
                .WillCascadeOnDelete(false);
        }
    }
}
