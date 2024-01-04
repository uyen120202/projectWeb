using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class GioHang
    {
        public GioHang()
        {
            ChiTietGhs = new HashSet<ChiTietGh>();
        }

        public string MaGh { get; set; } = null!;
        public int? TongTien { get; set; }
        public string? TenTaiKhoan { get; set; }

        public virtual TaiKhoanUser? TenTaiKhoanNavigation { get; set; }
        public virtual ICollection<ChiTietGh> ChiTietGhs { get; set; }
    }
}
