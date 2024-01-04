using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class Hang
    {
        public Hang()
        {
            Anhs = new HashSet<Anh>();
            ChiTietGhs = new HashSet<ChiTietGh>();
        }

        public string MaHang { get; set; } = null!;
        public string TenHang { get; set; } = null!;
        public int? DonGiaNhap { get; set; }
        public int? DonGiaBan { get; set; }
        public string? Ram { get; set; }
        public string? BoNho { get; set; }
        public string? HeDieuHanh { get; set; }
        public string? Camera { get; set; }
        public string? ManHinh { get; set; }
        public int? Slton { get; set; }
        public int? ThoiGianBaoHanh { get; set; }
        public int? SoLanMua { get; set; }
        public string? MoTa { get; set; }
        public string? MaDanhMuc { get; set; }
        public string? HinhAnh { get; set; }
        public string? Imei { get; set; }
        public bool? TrangThaiBan { get; set; }
        public string? Mau { get; set; }
        public string? Pin { get; set; }

        public virtual DanhMuc? MaDanhMucNavigation { get; set; }
        public virtual ICollection<Anh> Anhs { get; set; }
        public virtual ICollection<ChiTietGh> ChiTietGhs { get; set; }
    }
}
