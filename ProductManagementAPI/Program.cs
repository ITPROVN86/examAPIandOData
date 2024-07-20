
using BusinessObjects;
using ProductManagementAPI.Models;
using Services;

namespace ProductManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped(typeof(ShopOnlineDbContext));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            // Add services to the container.

            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7198") // Đổi thành tên miền của bạn
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin"); // Sử dụng CORS policy đã định nghĩa
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
