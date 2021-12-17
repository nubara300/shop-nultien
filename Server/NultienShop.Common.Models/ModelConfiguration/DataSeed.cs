using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NultienShop.DataAccess.Domain.Models;
using System;
using System.Collections.Generic;

namespace NultienShop.DataAccess.Domain.ModelConfiguration
{
    public class DataSeed
    {
        private static readonly int[] dataSeedCount = new int[10];
        private static Random randomPrice = new();

        public class ArticleSeed : IEntityTypeConfiguration<Article>
        {
            public void Configure(EntityTypeBuilder<Article> entity)
            {
                var collectionToAdd = new List<Article>();

                for (int i = 1; i <= dataSeedCount.Length; i++)
                {
                    collectionToAdd.Add(new Article { ArticleId = i, ArticleName = $"Article No.{i}", ArticlePrice = randomPrice.Next(10, 1000) });
                }

                entity.HasData(collectionToAdd);
            }
        }

        public class InventorySeed : IEntityTypeConfiguration<Inventory>
        {
            public void Configure(EntityTypeBuilder<Inventory> entity)
            {
                var collectionToAdd = new List<Inventory>() { };

                for (int i = 1; i <= dataSeedCount.Length; i++)
                {
                    collectionToAdd.Add(new Inventory { InventoryId = i, InventoryName = $"Inventory No.{i}", InventoryLocation = $"Inventory location id-{i}" });
                }

                entity.HasData(collectionToAdd);
            }
        }

        public class InventoryArticleSeed : IEntityTypeConfiguration<InventoryArticle>
        {
            public void Configure(EntityTypeBuilder<InventoryArticle> entity)
            {
                var collectionToAdd = new List<InventoryArticle>();

                for (int i = 1; i <= dataSeedCount.Length; i++)
                    collectionToAdd.Add(new InventoryArticle { InventoryArticleId = i, ArticleId = i, InventoryId = i, ArticleQuantity = randomPrice.Next(0, 500) });
               
                entity.HasData(collectionToAdd);
            }
        }

        public class CustomerSeed : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> entity)
            {
                List<Customer> collectionToAdd = new();

                for (int i = 1; i <= dataSeedCount.Length; i++)
                {
                    collectionToAdd.Add(new Customer { CustomerId = i, CustomerName = $"Customer {i}" });
                }

                entity.HasData(collectionToAdd);
            }
        }
    }
}