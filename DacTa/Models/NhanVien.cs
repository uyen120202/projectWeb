using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            Hdbans = new HashSet<Hdban>();
            Hdnhaps = new HashSet<Hdnhap>();
        }

        public string MaNv { get; set; } = null!;
        public string TenNv { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayBd { get; set; }
        public string? DiaChi { get; set; }
        public string MaChucVu { get; set; } = null!;
        public string? GhiChu { get; set; }

        public virtual ChucVu MaChucVuNavigation { get; set; } = null!;
        public virtual ICollection<Hdban> Hdbans { get; set; }
        public virtual ICollection<Hdnhap> Hdnhaps { get; set; }
    }
}
