using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLyNhaTro.DAL.Models
{
    public partial class QLNTModel : DbContext
    {
        public QLNTModel()
            : base("name=QLNTModel1")
        {
        }

        public virtual DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachThue> KhachThues { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<PhongTro> PhongTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDichVu>()
                .Property(e => e.SoLuong)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietDichVus)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 2);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietDichVus)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

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
