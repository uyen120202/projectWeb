﻿using System;
using System.Collections.Generic;

namespace DacTa.Models
{
    public partial class PhieuNhapKho
    {
        public string MaPnk { get; set; } = null!;
        public DateTime? NgayNhap { get; set; }
        public string? MaNv { get; set; }
    }
}
