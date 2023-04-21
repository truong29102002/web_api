using web_api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add scoped for repository
// services.AddScoped<IMyService, MyService>();
// Ví dụ, nếu ta đăng ký một đối tượng MyService với AddScoped trong program.cs, khi một đối tượng MyController được tạo ra, một phiên bản của MyService sẽ được tạo ra và được sử dụng trong phạm vi của MyController. Điều này đảm bảo rằng các đối tượng phụ thuộc của MyService sẽ chỉ được tạo một lần trong phạm vi của MyController , Trong đó IMyService là interface của MyService

//builder.Services.AddScoped<ISinhVien, SinhVienRepository>();

// add scoped for static repository
builder.Services.AddScoped<ISinhVien, SinhVienStaticRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
