using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        [HttpGet("{id}")] // http:localhost:xxx//api/sinhvien/{id}
        public IActionResult Get(Guid id)
        {
            try
            {
                var svt = sv.SingleOrDefault(x => x.id == id);
                if (svt == null)
                {
                    return NotFound();
                }
                return Ok(svt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
           
        }

        [HttpPost]
        public IActionResult CreateSv(SinhVien svn)
        {
            SinhVien svm = new SinhVien
            {
                id = Guid.NewGuid(),
                Name = svn.Name
            };
            sv.Add(svm);
            return Ok(new
            {
                Success = true,
                Data = sv
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSv(Guid id,  SinhVien svn)
        {
            try
            {
                var svt = sv.SingleOrDefault(x => x.id == id);
                if (svt == null)
                {
                    return NotFound();
                }
                if(svt.id != svn.id)
                {
                    return BadRequest();
                }
                else
                {
                    svt.id = svn.id;
                    svt.Name = svn.Name;
                }
                return Ok(svt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSv(Guid id)
        {
            try
            {
                var svt = sv.SingleOrDefault(x => x.id == id);
                if (svt == null)
                {
                    return NotFound();
                }
                sv.Remove(svt);
                return Ok(svt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
