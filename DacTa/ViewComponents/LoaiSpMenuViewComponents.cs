using DacTa.Models;
using DacTa.Repository;
using Microsoft.AspNetCore.Mvc;
namespace DacTa.ViewComponents
{
    public class LoaiSpMenuViewComponents: ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSpRepository;
        public LoaiSpMenuViewComponents(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSpRepository = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp= _loaiSpRepository.GetAllDanhMuc().OrderBy(x=>x.TenDanhMuc);
            return View(loaisp);
        }
    }
}
