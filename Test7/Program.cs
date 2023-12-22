using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Test7.Repositories;
using Test7.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Konfigurasi DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=sinar_tambang;Integrated Security=True;Encrypt=True;TrustServerCertificate=true;");
        });

        // Injeksi IMatakuliahRepository
        builder.Services.AddScoped<IMatakuliahRepository, MatakuliahRepository>();
        builder.Services.AddScoped<IDosenRepository, DosenRepository>();
        builder.Services.AddScoped<IMahasiswaRepository, MahasiswaRepository>();
        builder.Services.AddScoped<IPerkuliahanRepository, PerkuliahanRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
