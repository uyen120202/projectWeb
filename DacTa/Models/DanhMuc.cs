using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            Hangs = new HashSet<Hang>();
        }

        public string MaDanhMuc { get; set; } = null!;
        public string? TenDanhMuc { get; set; }

        public virtual ICollection<Hang> Hangs { get; set; }
    }
}
