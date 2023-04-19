using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Models_Repository;
using web_api.Repository;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienRepositoryController : ControllerBase
    {
        private readonly ISinhVien _sinhvien;

        public SinhVienRepositoryController(ISinhVien sinhVien)
        {
            _sinhvien = sinhVien;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_sinhvien.GetAll());
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var sv = _sinhvien.GetById(id);
                if (sv == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(sv);
                }
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _sinhvien.DeleteById(id);
                return Ok();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPost]
        public IActionResult Add(SinhVienData sinhVienData)
        {
            try
            {
                return Ok(_sinhvien.Add(sinhVienData));
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SinhVienMR sv)
        {
            if(id != sv.Id)
            {
                return NotFound(id);
            }
            try
            {
                _sinhvien.Update(sv);
                return NoContent();
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

    }
}
