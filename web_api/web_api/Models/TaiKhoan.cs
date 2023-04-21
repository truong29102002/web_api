using System;
using System.Collections.Generic;

namespace web_api.Models
{
    public partial class TaiKhoan
    {
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public int? Id { get; set; }
        public bool? TrangThai { get; set; }
        public int? IdGv { get; set; }

        public virtual GiaoVien? IdGvNavigation { get; set; }
        public virtual SinhVien? IdNavigation { get; set; }
    }
}
