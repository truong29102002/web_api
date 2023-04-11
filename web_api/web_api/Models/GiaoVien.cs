using System;
using System.Collections.Generic;

namespace web_api.Models
{
    public partial class GiaoVien
    {
        public GiaoVien()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
