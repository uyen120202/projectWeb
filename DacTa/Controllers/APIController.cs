using DacTa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DacTa.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class APIController : ControllerBase
    {
        QuanLyBanHang2Context db = new QuanLyBanHang2Context();

        
        [HttpGet("{maSP}")]
        public int? getPriceOfProduct(string maSP)
        {
            int? donGia = db.Hangs.FirstOrDefault(x => x.MaHang == maSP).DonGiaBan; 
            return donGia; 
        }

        [HttpPost("")]
        public bool AddHoaDon(HDBanDTO hdbanDTO)
        {
            var hdban = new Hdban();
            hdban.MaHdb = hdbanDTO.MaHdb;
            hdban.NgayLap = hdbanDTO.NgayLap;
            hdban.MaKh = hdbanDTO.MaKh;
            hdban.MaNv = hdbanDTO.MaNv;
            hdban.TongTien = 0; 
            db.Hdbans.Add(hdban);
            try
            {
               
                db.SaveChanges(); 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; 
            }
        }

        [HttpPost("chitiethoadon")]
        public bool AddChiTietHDB(ChiTietHDBDTO cthdb)
        {
            try
            {
                var chitiet = new ChiTietHdb();
                chitiet.MaHdb = cthdb.MaHdb;
                chitiet.MaHang = cthdb.MaHang;
                chitiet.SoLuong = cthdb.SoLuong;
                chitiet.ThanhTien = cthdb.ThanhTien;
                db.ChiTietHdbs.Add(chitiet);
                db.SaveChanges();
                return true;
            } catch(Exception ex)
            {
                return false; 
            }
           
        }

    }

    
}
