using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NultienShop.DataAccess.Domain;
using System.IO.Compression;

namespace NultienShopREST
{
    public static class ServiceExtensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            _ = bool.TryParse(configuration.GetSection("useDatabase").Value, out bool useDatabase);

            services.AddDbContext<AppDBContext>(options =>
            {
                if (useDatabase)
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }
                else
                {
                    options.UseInMemoryDatabase("NultienShopDB");
                }
            });

            //add db context and set other database settings
            services.AddScoped<DbContext, AppDBContext>();
        }

        public static void MapInterfaceImplementation(this IServiceCollection services)
        {
            // add BL classes here

            // add DAL classes here

            // add other services here
            services.AddHttpClient();
        }

        public static void ConfigureResponseCompresion(this IServiceCollection services)
        {
            // Manage response compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
        }
    }
}