using web_api.Data;
using web_api.Models_Repository;

namespace web_api.Repository
{
    public interface ISinhVien
    {
        List<SinhVienMR> GetAll();
        SinhVienMR GetById(int id);
        SinhVienMR Add(SinhVienData v);
        void Update(SinhVienMR v);
        void DeleteById(int id);
    }
}
