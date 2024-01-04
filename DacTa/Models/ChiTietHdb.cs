using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class ChiTietHdb
    {
        public string MaHdb { get; set; } = null!;
        public string MaHang { get; set; } = null!;
        public int? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }

        [JsonIgnore]
        public virtual Hang MaHangNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Hdban MaHdbNavigation { get; set; } = null!;
    }
}
