using DacTa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DacTa.Areas.Admin.Controllers
{
    
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QuanLyBanHang2Context db=new QuanLyBanHang2Context();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route ("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 12;//số sản phẩm trên 1 trang
            int pageNumber = page == null || page < 1 ? 1 : page.Value;

            var lstsanpham = db.Hangs.AsNoTracking().OrderBy(x => x.TenHang);
            PagedList<Hang> pagelst = new PagedList<Hang>(lstsanpham, pageNumber, pageSize);
            return View(pagelst);
        }
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs.OrderBy
                    (x => x.TenDanhMuc), "MaDanhMuc", "TenDanhMuc");
            return View();

        }
        [Route("ThemSanPham")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ThemSanPham(Hang hang)
        {
            if (ModelState.IsValid)
            {
                db.Hangs.Add(hang);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(hang);
        }
        [Route("danhmuchoadonban")]
        public IActionResult DanhMucHoaDonBan(int? page)
        {
            int pageSize = 8;//số khách hàng trên 1 trang
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var lsthdb = db.Hdbans.Include(x => x.MaNvNavigation).Include(x => x.MaKhNavigation).OrderBy(x => x.MaHdb);

            PagedList<Hdban> pagelst = new PagedList<Hdban>(lsthdb, pageNumber, pageSize);
            return View(pagelst);
        }

        [Route("ChiTietHoaDonBan")]
        public IActionResult ChiTietHoaDonBan(string maHdb)
        {

            var lstcthdb = db.ChiTietHdbs.Where(x => x.MaHdb == maHdb)
                .Include(x => x.MaHangNavigation).Include(x => x.MaHdbNavigation).ToList();
            var hoaDonBan = db.Hdbans
                    .Include(x => x.MaNvNavigation)
                    .Include(x => x.MaKhNavigation)
                    .SingleOrDefault(x => x.MaHdb == maHdb);
            ViewBag.TenNv = hoaDonBan?.MaNvNavigation?.TenNv;
            ViewBag.NgayLap = hoaDonBan?.NgayLap;
            ViewBag.TenKh = hoaDonBan?.MaKhNavigation?.TenKh;
            ViewBag.TongTien = hoaDonBan?.TongTien;
            return View(lstcthdb);
        }
        [Route("ThemHoaDonBan")]
        [HttpGet]
        public IActionResult ThemHoaDonBan()
        {
            ViewBag.MaNv = new SelectList(db.NhanViens.OrderBy
                    (x => x.MaNv), "MaNv", "TenNv");
            ViewBag.MaKh = new SelectList(db.KhachHangs.OrderBy
                    (x => x.MaKh), "MaKh", "TenKh");
            ViewBag.MaSp = new SelectList(db.Hangs.OrderBy
                    (x => x.MaHang), "MaHang", "TenHang");
            return View();

        }
        [Route("ThemHoaDonBan")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ThemHoaDonBan(Hdban hdban)
        {
            if (ModelState.IsValid)
            {
                db.Hdbans.Add(hdban);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(hdban);
        }
    }
}
