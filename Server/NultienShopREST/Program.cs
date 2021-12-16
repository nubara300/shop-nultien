using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NultienShop.DataAccess.Domain;
using System;
using System.IO;
using System.Linq;

namespace NultienShopREST
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

            Configuration = new ConfigurationBuilder()
                .AddJsonFile(settingsPath, optional: false, true)
                .AddEnvironmentVariables()
                .Build();

            _ = bool.TryParse(Configuration.GetSection("useDatabase").Value, out bool useDatabase);

            var host = CreateHostBuilder(args).Build();

            if (useDatabase != true)
            {
                //initialze data
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
