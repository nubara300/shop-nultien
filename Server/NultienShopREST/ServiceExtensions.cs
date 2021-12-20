using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NultienShop.BusinessLogic;
using NultienShop.DataAccess;
using NultienShop.DataAccess.Domain;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System.IO.Compression;
using Mapster;
using MapsterMapper;

namespace NultienShopREST
{
    public static class ServiceExtensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            _ = bool.TryParse(configuration.GetSection("useEFCoreLogging").Value, out bool useLogging);
            _ = bool.TryParse(configuration.GetSection("useInMemoryDatabase").Value, out bool useInMemoryDatabase);

            services.AddDbContext<TheShopContext>(options =>
            {
                if (useLogging)
                {
                    options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
                    options.EnableSensitiveDataLogging();
                }

                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("NultienShopDB");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), o =>
                    {
                        o.EnableRetryOnFailure(2);
                        o.CommandTimeout(2);
                    });
                }
            });

            //add db context and set other database settings
            services.AddScoped<DbContext, TheShopContext>();
        }

        public static void MapInterfaceImplementation(this IServiceCollection services)
        {
            // add DAL classes here
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            // add BL classes here
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IOrderService, OrderService>();

            // add other services here
            services.AddHttpClient();
        }

        public static void ConfigureResponseCompression(this IServiceCollection services)
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

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}