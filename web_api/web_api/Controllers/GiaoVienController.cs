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
            return Ok(_contextAccessor.GiaoViens.ToList());
        }

    }
}
