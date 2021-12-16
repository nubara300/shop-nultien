using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NultienShop.DataAccess.Domain.Models;
using System;
using System.Collections.Generic;

namespace NultienShop.DataAccess.Domain.ModelConfiguration
{
    public class DataSeed
    {
        public class ArticleSeed : IEntityTypeConfiguration<Article>
        {
            int[] array = new int[10];
            //Array<int>[10] collection = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random randomPrice = new();
            public void Configure(EntityTypeBuilder<Article> entity)
            {
                var collectionToAdd = new List<Article>();

                for (int i = 1; i <= array.Length; i++)
                {
                    collectionToAdd.Add(new Article { ArticleId = i, ArticleName = $"Article No.{i}", ArticlePrice = randomPrice.Next(10, 1000) });
                } 

                entity.HasData(collectionToAdd);
            }
        }
    }
}