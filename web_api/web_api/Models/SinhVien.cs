using System;
using System.Collections.Generic;

namespace web_api.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Diachi { get; set; }
        public string? Lop { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
