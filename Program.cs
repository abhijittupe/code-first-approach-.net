using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<YcpJuly23CodeFirstContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("YcpJuly23CodeFirstContext")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Departments}/{action=Index}/{id?}");

            app.Run();
        }
    }
}