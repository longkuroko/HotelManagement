namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model111")
        {
        }

        public virtual DbSet<CHITIETDICHVU> CHITIETDICHVUs { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIKHACHHANG> LOAIKHACHHANGs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<LOAITIENNGHI> LOAITIENNGHIs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHANCONG> PHANCONGs { get; set; }
        public virtual DbSet<PHIEUDICHVU> PHIEUDICHVUs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TANGLAU> TANGLAUs { get; set; }
        public virtual DbSet<THUEPHONG> THUEPHONGs { get; set; }
        public virtual DbSet<TIENNGHI> TIENNGHIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDICHVU>()
                .Property(e => e.SoPhieuDV)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDICHVU>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.SoPhieuTP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.SoPhieuDV)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.SoPhieuTP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .Property(e => e.MaDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .HasMany(e => e.CHITIETDICHVUs)
                .WithRequired(e => e.DICHVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKhach)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaLoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIKHACHHANG>()
                .Property(e => e.MaLoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.MaLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITIENNGHI>()
                .Property(e => e.MaLoaiTienNghi)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITIENNGHI>()
                .HasMany(e => e.TIENNGHIs)
                .WithRequired(e => e.LOAITIENNGHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasOptional(e => e.PHANCONG)
                .WithRequired(e => e.NHANVIEN);

            modelBuilder.Entity<PHANCONG>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PHANCONG>()
                .Property(e => e.Ca)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDICHVU>()
                .Property(e => e.SoPhieuDV)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDICHVU>()
                .Property(e => e.SoPhieuTP)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDICHVU>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDICHVU>()
                .HasMany(e => e.CHITIETDICHVUs)
                .WithRequired(e => e.PHIEUDICHVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.STTTang)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.TIENNGHIs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TANGLAU>()
                .Property(e => e.STTTang)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.SoPhieuTP)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.MaKhach)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.THUEPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIENNGHI>()
                .Property(e => e.MaLoaiTienNghi)
                .IsUnicode(false);

            modelBuilder.Entity<TIENNGHI>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);
        }
    }
}
