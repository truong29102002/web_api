using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_api.Data;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        private readonly dbapiContext _contextAccessor;

        private readonly AppSetting _appSettings;
        public GiaoVienController(IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _contextAccessor = new dbapiContext();
            _appSettings = optionsMonitor.CurrentValue; // auto map data sang AppSettings trong appsettings.json và lấy giá trị của SecretKey sau đó chuyển sang Program.cs để mã hóa 
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_contextAccessor.GiaoViens.ToList());
        }

        [HttpPost("Admin/Login")]
        public IActionResult Login(LoginData loginData)
        {
            var user = _contextAccessor.TaiKhoans.SingleOrDefault(x => x.Username == loginData.Username && x.Password == loginData.Password && x.TrangThai == true);
            if (user == null)
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Message = "Tai khoan mat khau khong dung"
                });
            }
            // cấp token
            return Ok(new APIResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            });
        }
        // tạo token 
        private string GenerateToken(TaiKhoan taiKhoan) // token chua thong tin nguoi dung 
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDesciption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Username", taiKhoan.Username),
                    new Claim("Password", taiKhoan.Password),
                    new Claim("IdGv", taiKhoan.IdGv.ToString()),
                    // roles 
                    new Claim("TokenID", Guid.NewGuid().ToString()) // tao token authorization
                }),
                Expires = DateTime.UtcNow.AddMinutes(1), // thời gian token hết hạn
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature) // thực hiện ký 
            };

            var token = jwtTokenHandler.CreateToken(tokenDesciption); // security token


            return jwtTokenHandler.WriteToken(token);
        }



    }
}
