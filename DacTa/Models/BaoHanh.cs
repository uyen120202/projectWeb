using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class BaoHanh
    {
        public string MaBh { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayTra { get; set; }
        public int? TongTien { get; set; }
        public string? GhiChu { get; set; }
        public string? Imei { get; set; }
    }
}
