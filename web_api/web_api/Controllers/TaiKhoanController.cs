using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly dbapiContext _contextAccessor;
        public TaiKhoanController()
        {
            _contextAccessor = new dbapiContext();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allTk = _contextAccessor.TaiKhoans.ToList();
            
            return Ok(allTk);
        }
    }
}
