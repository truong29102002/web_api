using web_api.Data;
using web_api.Models_Repository;

namespace web_api.Repository
{
    public class SinhVienStaticRepository : ISinhVien
    {
        static List<SinhVienMR> list = new List<SinhVienMR>
        {
            new SinhVienMR {Id = 1, Name = "Truong", Diachi ="Nam Dinh", Lop="KTPM01"},
            new SinhVienMR {Id = 2, Name = "Loan", Diachi ="Bac Giang", Lop="KTPM01"},
            new SinhVienMR {Id = 3, Name = "Thanh", Diachi ="Ha Noi", Lop="KTPM01"},
            new SinhVienMR {Id = 4, Name = "Ha", Diachi ="Nam Dinh", Lop="KTPM01"},
            new SinhVienMR {Id = 5, Name = "Long", Diachi ="Bac Ninh", Lop="KTPM01"},
            new SinhVienMR {Id = 6, Name = "Trung", Diachi ="Hai Phong", Lop="KTPM01"}
        };
        SinhVienMR ISinhVien.Add(SinhVienData v)
        {
            var svt = new SinhVienMR
            {
                Id = list.Max(x=>x.Id) + 1,
                Name = v.Name,
                Diachi = v.Diachi,
                Lop = v.Lop,
            };
            list.Add(svt);
            return svt;
        }

        void ISinhVien.DeleteById(int id)
        {
            var sv = list.SingleOrDefault(x => x.Id == id);
            list.Remove(sv);
        }

        List<SinhVienMR> ISinhVien.GetAll()
        {
            return list;
        }

        SinhVienMR ISinhVien.GetById(int id)
        {
            return list.SingleOrDefault(x => x.Id == id);
        }

        void ISinhVien.Update(SinhVienMR v)
        {
            var sv = list.SingleOrDefault(x => x.Id == v.Id);
            if (sv != null)
            {
                sv.Name = v.Name;
                sv.Diachi = v.Diachi;
                sv.Lop = v.Lop;
            }
        }
    }
}
