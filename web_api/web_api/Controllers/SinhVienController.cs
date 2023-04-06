using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        public static List<SinhVien> sv = new List<SinhVien>();
        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            return Ok(sv);
        }
        [HttpPost]
        public IActionResult CreateSv(SinhVien svn)
        {
            SinhVien svm = new SinhVien
            {
                id= Guid.NewGuid(), Name = svn.Name
            };
            sv.Add(svm);
            return Ok(new
            {
                Success = true,
                Data = sv
            });
        }
    }
}
