using web_api.Data;
using web_api.Models;
using web_api.Models_Repository;

namespace web_api.Repository
{
    public class SinhVienRepository : ISinhVien
    {
        private readonly dbapiContext dbapiContext;
        public SinhVienRepository()
        {
            dbapiContext = new dbapiContext();
        }
        public SinhVienMR Add(SinhVienData v)
        {
            var _sinhVien = new SinhVien { Name = v.Name,
            Diachi = v.Diachi, Lop = v.Lop};
            dbapiContext.Add(_sinhVien);
            dbapiContext.SaveChanges();
            return new SinhVienMR {Id = _sinhVien.Id, Name = _sinhVien.Name, Diachi = _sinhVien.Diachi, Lop = _sinhVien.Lop};
        }

        public void DeleteById(int id)
        {
           var sinhVien = dbapiContext.SinhViens.SingleOrDefault(x => x.Id == id);
            if(sinhVien != null)
            {
                dbapiContext.Remove(sinhVien);
                dbapiContext.SaveChanges();
            }
           
        }

        public List<SinhVienMR> GetAll()
        {
            var sinhVien = dbapiContext.SinhViens.Select(x => new SinhVienMR
            {
                Id = x.Id,
                Name = x.Name,
                Diachi = x.Diachi,
                Lop = x.Lop
            });
            return sinhVien.ToList();
        }

        public SinhVienMR GetById(int id)
        {
            var sinhVien = dbapiContext.SinhViens.SingleOrDefault(x => x.Id == id);
            if(sinhVien != null)
            {
                return new SinhVienMR
                {
                    Id = sinhVien.Id,
                    Name = sinhVien.Name,
                    Diachi = sinhVien.Diachi,
                    Lop = sinhVien.Lop
                };
            }
            return null;
        }

        public void Update(SinhVienMR v)
        {
            var sinhVien = dbapiContext.SinhViens.SingleOrDefault(x => x.Id == v.Id);
            if(sinhVien != null)
            {
                sinhVien.Name = v.Name;
                sinhVien.Diachi = v.Diachi;
                sinhVien.Lop = v.Lop;
                dbapiContext.SaveChanges();
            }
        }
    }
}
