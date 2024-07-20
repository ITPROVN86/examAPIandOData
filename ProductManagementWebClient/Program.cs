using Services;

namespace ProductManagementWebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            void ConfigureHttpClient(HttpClient client)
            {
                client.BaseAddress = new Uri("https://localhost:7289/odata/"); // Replace with your Web API base URL
            }

            builder.Services.AddHttpClient<ICategoryService, CategoryService>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IProductService, ProductService>(ConfigureHttpClient);
            builder.Services.AddHttpClient<ICustomerService, CustomerService>(ConfigureHttpClient);
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseCors("AllowSpecificOrigin"); // Sử dụng CORS policy đã định nghĩa
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
