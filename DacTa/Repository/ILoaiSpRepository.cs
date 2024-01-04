using DacTa.Models;
namespace DacTa.Repository
{
    public interface ILoaiSpRepository
    {
        DanhMuc Add(DanhMuc danhMuc);
        DanhMuc Update(DanhMuc danhMuc);
        DanhMuc Delete(String MaDanhMuc);
        DanhMuc GetDanhMuc(String MaDanhMuc);
        IEnumerable<DanhMuc> GetAllDanhMuc();
    }
}
