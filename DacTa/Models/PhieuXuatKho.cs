using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class PhieuXuatKho
    {
        public string MaPxk { get; set; } = null!;
        public DateTime? NgayXuat { get; set; }
        public string MaNv { get; set; } = null!;
    }
}
