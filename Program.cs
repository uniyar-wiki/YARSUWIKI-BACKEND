using YARSUWIKI.DAL;
using YARSUWIKI.DAL.Interfaces;
using YARSUWIKI.DAL.Repositories;

namespace YARSUWIKI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHost(args);
        host.Run();
    }

    public static IHost CreateHost(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureServices((hostContext, services) =>
            {
                // Add PostgreSQL DbContext with connection string
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(GetConnectionString()));
            })
            .Build();

    private static string GetConnectionString()
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = "127.0.0.1", // Docker container IP or hostname
            Port = 5432, // PostgreSQL port
            Username = "nikita",
            Password = "dolbayeb",
            Database = "yarsuwiki",
            Pooling = true,
        };

        return builder.ConnectionString;
    }
}

