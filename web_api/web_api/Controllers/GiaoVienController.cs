using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        private readonly dbapiContext _contextAccessor;
        public GiaoVienController()
        {
            _contextAccessor = new dbapiContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var allGV = _contextAccessor.GiaoViens.ToList();
            return Ok(allGV);
        }
    }
}
