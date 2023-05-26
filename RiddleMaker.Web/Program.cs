using Microsoft.EntityFrameworkCore;

using RiddleMaker.Common;
using RiddleMaker.Data;
using RiddleMaker.Services.Data;
using RiddleMaker.Services.Mapping;

namespace RiddleMaker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<RiddleMakerContext>(opt => 
            opt.UseSqlServer(ConnectionConfiguration.ConnectionString));

			builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<RiddleMakerProfile>();
            });

            builder.Services.AddTransient<IRiddlesService, RiddlesService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}