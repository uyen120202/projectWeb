using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DacTa.Models
{
    public partial class QuanLyBanHang2Context : DbContext
    {
        public QuanLyBanHang2Context()
        {
        }

        public QuanLyBanHang2Context(DbContextOptions<QuanLyBanHang2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Anh> Anhs { get; set; } = null!;
        public virtual DbSet<BaoHanh> BaoHanhs { get; set; } = null!;
        public virtual DbSet<ChiTietGh> ChiTietGhs { get; set; } = null!;
        public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; } = null!;
        public virtual DbSet<ChiTietHdn> ChiTietHdns { get; set; } = null!;
        public virtual DbSet<ChiTietPnk> ChiTietPnks { get; set; } = null!;
        public virtual DbSet<ChiTietPxk> ChiTietPxks { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<Hang> Hangs { get; set; } = null!;
        public virtual DbSet<Hdban> Hdbans { get; set; } = null!;
        public virtual DbSet<Hdnhap> Hdnhaps { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<PhieuNhapKho> PhieuNhapKhos { get; set; } = null!;
        public virtual DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<TaiKhoanUser> TaiKhoanUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=QuanLyBanHang2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anh>(entity =>
            {
                entity.HasKey(e => e.MaAnh)
                    .HasName("pk_anh");

                entity.ToTable("Anh");

                entity.Property(e => e.MaAnh)
                    .HasMaxLength(10)
                    .HasColumnName("maAnh");

                entity.Property(e => e.MaHang)
                    .HasMaxLength(10)
                    .HasColumnName("maHang");

                entity.Property(e => e.TenAnh)
                    .HasMaxLength(10)
                    .HasColumnName("tenAnh");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany(p => p.Anhs)
                    .HasForeignKey(d => d.MaHang)
                    .HasConstraintName("fk_anh_hang");
            });

            modelBuilder.Entity<BaoHanh>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BaoHanh");

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.Imei)
                    .HasMaxLength(255)
                    .HasColumnName("IMEI");

                entity.Property(e => e.MaBh)
                    .HasMaxLength(10)
                    .HasColumnName("MaBH");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.Property(e => e.NgayTra).HasColumnType("date");
            });

            modelBuilder.Entity<ChiTietGh>(entity =>
            {
                entity.HasKey(e => new { e.MaGh, e.MaHang })
                    .HasName("pk_ctgh");

                entity.ToTable("ChiTietGH");

                entity.Property(e => e.MaGh)
                    .HasMaxLength(10)
                    .HasColumnName("maGH");

                entity.Property(e => e.MaHang)
                    .HasMaxLength(10)
                    .HasColumnName("maHang");

                entity.HasOne(d => d.MaGhNavigation)
                    .WithMany(p => p.ChiTietGhs)
                    .HasForeignKey(d => d.MaGh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ctgh_gh");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany(p => p.ChiTietGhs)
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ctgh_hang");
            });

            modelBuilder.Entity<ChiTietHdb>(entity =>
            {
                entity.HasNoKey();
                entity.HasKey(e => new { e.MaHang, e.MaHdb });

                entity.ToTable("ChiTietHDB");

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.MaHdb)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDB");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHD__MaHan__5812160E");

                entity.HasOne(d => d.MaHdbNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHdb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHD__MaHDB__59063A47");
            });

            modelBuilder.Entity<ChiTietHdn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ChiTietHDN");

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.MaHdn)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDN");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHD__MaHan__59FA5E80");

                entity.HasOne(d => d.MaHdnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHdn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHD__MaHDN__5AEE82B9");
            });

            modelBuilder.Entity<ChiTietPnk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ChiTietPNK");

                entity.Property(e => e.DonViTinh).HasMaxLength(255);

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.MaPnk)
                    .HasMaxLength(10)
                    .HasColumnName("MaPNK");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPN__MaHan__5BE2A6F2");

                entity.HasOne(d => d.MaPnkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaPnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPN__MaPNK__5CD6CB2B");
            });

            modelBuilder.Entity<ChiTietPxk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ChiTietPXK");

                entity.Property(e => e.DonViTinh).HasMaxLength(255);

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.MaPxk)
                    .HasMaxLength(10)
                    .HasColumnName("MaPXK");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPX__MaHan__5DCAEF64");

                entity.HasOne(d => d.MaPxkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaPxk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPX__MaPXK__5EBF139D");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu);

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaChucVu).HasMaxLength(10);

                entity.Property(e => e.TenChucVu).HasMaxLength(255);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc)
                    .HasName("pk_danhmuc");

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDanhMuc).HasMaxLength(10);

                entity.Property(e => e.TenDanhMuc).HasMaxLength(10);
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.MaGh)
                    .HasName("pk_giohang");

                entity.ToTable("GioHang");

                entity.Property(e => e.MaGh)
                    .HasMaxLength(10)
                    .HasColumnName("maGH");

                entity.Property(e => e.TenTaiKhoan).HasMaxLength(10);

                entity.HasOne(d => d.TenTaiKhoanNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.TenTaiKhoan)
                    .HasConstraintName("FK__GioHang__TenTaiK__5FB337D6");
            });

            modelBuilder.Entity<Hang>(entity =>
            {
                entity.HasKey(e => e.MaHang)
                    .HasName("PK_tHang");

                entity.ToTable("Hang");

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.BoNho).HasMaxLength(255);

                entity.Property(e => e.Camera).HasMaxLength(255);

                entity.Property(e => e.HeDieuHanh).HasMaxLength(255);

                entity.Property(e => e.HinhAnh).HasMaxLength(10);

                entity.Property(e => e.Imei)
                    .HasMaxLength(10)
                    .HasColumnName("IMEI");

                entity.Property(e => e.MaDanhMuc).HasMaxLength(10);

                entity.Property(e => e.ManHinh).HasMaxLength(255);

                entity.Property(e => e.Mau).HasMaxLength(255);

                entity.Property(e => e.MoTa).HasColumnType("text");

                entity.Property(e => e.Pin).HasMaxLength(255);

                entity.Property(e => e.Ram).HasMaxLength(255);

                entity.Property(e => e.Slton).HasColumnName("SLTon");

                entity.Property(e => e.TenHang).HasMaxLength(255);

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.Hangs)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .HasConstraintName("FK_PersonOrder");
            });

            modelBuilder.Entity<Hdban>(entity =>
            {
                entity.HasKey(e => e.MaHdb);

                entity.ToTable("HDBan");

                entity.Property(e => e.MaHdb)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDB");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hdbans)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HDBan__MaKH__619B8048");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Hdbans)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HDBan__MaNV__628FA481");
            });

            modelBuilder.Entity<Hdnhap>(entity =>
            {
                entity.HasKey(e => e.MaHdn);

                entity.ToTable("HDNhap");

                entity.Property(e => e.MaHdn)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDN");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(10)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayNhap).HasColumnType("date");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.Hdnhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HDNhap__MaNCC__6383C8BA");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Hdnhaps)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HDNhap__MaNV__6477ECF3");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(255)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TenTaiKhoan).HasMaxLength(10);

                entity.HasOne(d => d.TenTaiKhoanNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.TenTaiKhoan)
                    .HasConstraintName("FK_KhachHang_TaiKhoanUser");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK_tNCC");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(10)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(255)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.GhiChu).HasMaxLength(255);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.MaChucVu).HasMaxLength(10);

                entity.Property(e => e.NgayBd)
                    .HasColumnType("date")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(255)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaChucVu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__MaChuc__66603565");
            });

            modelBuilder.Entity<PhieuNhapKho>(entity =>
            {
                entity.HasKey(e => e.MaPnk)
                    .HasName("PK_PhieuNhapKho_1");

                entity.ToTable("PhieuNhapKho");

                entity.Property(e => e.MaPnk)
                    .HasMaxLength(10)
                    .HasColumnName("MaPNK");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayNhap).HasColumnType("date");
            });

            modelBuilder.Entity<PhieuXuatKho>(entity =>
            {
                entity.HasKey(e => e.MaPxk);

                entity.ToTable("PhieuXuatKho");

                entity.Property(e => e.MaPxk)
                    .HasMaxLength(10)
                    .HasColumnName("MaPXK");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayXuat).HasColumnType("date");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaBaoMat).HasMaxLength(20);

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MatKhau).HasMaxLength(20);

                entity.Property(e => e.TenTk)
                    .HasMaxLength(20)
                    .HasColumnName("TenTK");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_taikhoan_nhanvien");
            });

            modelBuilder.Entity<TaiKhoanUser>(entity =>
            {
                entity.HasKey(e => e.TenTaiKhoan)
                    .HasName("pk_TaiKhoanUser");

                entity.ToTable("TaiKhoanUser");

                entity.Property(e => e.TenTaiKhoan).HasMaxLength(10);

                entity.Property(e => e.MatKhau).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
