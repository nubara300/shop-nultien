﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NultienShop.BusinessLogic;
using NultienShop.DataAccess;
using NultienShop.DataAccess.Domain;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
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
            });

            //add db context and set other database settings
            services.AddScoped<DbContext, AppDBContext>();
        }

        public static void MapInterfaceImplementation(this IServiceCollection services)
        {
            // add DAL classes here
            services.AddTransient<IBaseRepository,BaseRepository>();
            services.AddTransient<IInventoryRepository,InventoryRepository>();

            // add BL classes here
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInventoryService, InventoryService>();

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