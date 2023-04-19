using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        //private readonly dbapiContext _context;

        //public SinhVienController(dbapiContext context) {
        //    _context = context;
        //}
        public static dbapiContext context = new dbapiContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var ds = context.SinhViens.ToList();
                return Ok(ds);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            try
            {
                var getId = context.SinhViens.SingleOrDefault(x => x.Id == id);
                if (getId != null)
                {
                    return Ok(getId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        public IActionResult CreateNSV(SinhVienData data)
        {
            try
            {
                var svm = new SinhVien{ Name = data.Name, Diachi = data.Diachi, Lop = data.Lop };
                context.Add(svm);
                context.SaveChanges();
                return Ok(new
                {
                    Content = "Them thanh cong",
                    Data = svm
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")] // update sinhvien 
        public IActionResult UpdateSV(int id, SinhVienData sv)
        {
            try
            {
                var getId = context.SinhViens.SingleOrDefault(x => x.Id == id);
                if (getId != null)
                {
                    getId.Name = sv.Name;
                    getId.Diachi = sv.Diachi;
                    getId.Lop = sv.Lop;
                    context.SaveChanges();
                    return Ok(getId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSV(int id) {
            try
            {
                var getId = context.SinhViens.SingleOrDefault(x => x.Id == id);
                if (getId != null)
                {
                    context.Remove(getId);
                    context.SaveChanges();
                    return Ok("Deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
