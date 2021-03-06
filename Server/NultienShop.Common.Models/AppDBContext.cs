using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NultienShop.DataAccess.Domain.Models;
using System.Reflection;

namespace NultienShop.DataAccess.Domain
{
    public class TheShopContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleOrder> ArticleOrder { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryArticle> InventoryArticle { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        public TheShopContext(DbContextOptions<TheShopContext> options) : base(options)
        {
        }

        public TheShopContext(DbContextOptions<TheShopContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}