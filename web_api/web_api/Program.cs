using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using web_api.Data;
using web_api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//==========================================
// add scoped for repository
// services.AddScoped<IMyService, MyService>();
// Ví dụ, nếu ta đăng ký một đối tượng MyService với AddScoped trong program.cs, khi một đối tượng MyController được tạo ra, một phiên bản của MyService sẽ được tạo ra và được sử dụng trong phạm vi của MyController. Điều này đảm bảo rằng các đối tượng phụ thuộc của MyService sẽ chỉ được tạo một lần trong phạm vi của MyController , Trong đó IMyService là interface của MyService

//builder.Services.AddScoped<ISinhVien, SinhVienRepository>();

// add scoped for static repository
builder.Services.AddScoped<ISinhVien, SinhVienStaticRepository>();

// config for authen

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings")); // map class AppSetting to section in json AppSettings

var secertKey = builder.Configuration["AppSettings:SecretKey"]; // lấy secret key in appsetting


var secertKeyBytes = Encoding.UTF8.GetBytes(secertKey); // convert secretKey string to bytes

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        // tự cấp token
        ValidateIssuer = false,
        ValidateAudience = false,

        // ký vào token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secertKeyBytes),

        ClockSkew = TimeSpan.Zero
    };
});
//========================================================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// add authen
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
