using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NultienShop.DataAccess.Domain.Models;

namespace NultienShop.DataAccess.Domain.ModelConfiguration
{
    public class DataSeed
    {
        public class ArticleSeed : IEntityTypeConfiguration<Article>
        {
            public void Configure(EntityTypeBuilder<Article> entity)
            {
                entity.HasData(InitialData.ArticleData);
            }
        }

        public class InventorySeed : IEntityTypeConfiguration<Inventory>
        {
            public void Configure(EntityTypeBuilder<Inventory> entity)
            {
                entity.HasData(InitialData.InventoryData);
            }
        }

        public class InventoryArticleSeed : IEntityTypeConfiguration<InventoryArticle>
        {
            public void Configure(EntityTypeBuilder<InventoryArticle> entity)
            {
                entity.HasData(InitialData.InventoryArticleData);
            }
        }

        public class CustomerSeed : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> entity)
            {
                entity.HasData(InitialData.CustomerData);
            }
        }
    }
}