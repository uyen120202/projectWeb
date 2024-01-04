namespace DacTa.Models
{
    public class ChiTietHDBDTO
    {
        public string MaHdb { get; set; } = null!;
        public string MaHang { get; set; } = null!;
        public int? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public int? ThanhTien { get; set; }
    }
}
