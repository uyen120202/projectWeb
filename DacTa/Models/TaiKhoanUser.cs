using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class TaiKhoanUser
    {
        public TaiKhoanUser()
        {
            GioHangs = new HashSet<GioHang>();
            KhachHangs = new HashSet<KhachHang>();
        }

        public string TenTaiKhoan { get; set; } = null!;
        public string? MatKhau { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
