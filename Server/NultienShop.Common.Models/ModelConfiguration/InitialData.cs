using System.Collections.Generic;
using NultienShop.DataAccess.Domain.Models;

namespace NultienShop.DataAccess.Domain.ModelConfiguration
{
    public static class InitialData
    {
        public static List<Article> ArticleData = new()
        {
            new Article { ArticleId = 1, ArticleName = "Article No.1", ArticlePrice = 100 },
            new Article { ArticleId = 2, ArticleName = "Article No.2", ArticlePrice = 350 },
            new Article { ArticleId = 3, ArticleName = "Article No.3", ArticlePrice = 750 },
            new Article { ArticleId = 4, ArticleName = "Article No.4", ArticlePrice = 400 },
            new Article { ArticleId = 5, ArticleName = "Article No.5", ArticlePrice = 600 },
            new Article { ArticleId = 6, ArticleName = "Article No.6", ArticlePrice = 2000 },
            new Article { ArticleId = 7, ArticleName = "Article No.7", ArticlePrice = 400 },
            new Article { ArticleId = 8, ArticleName = "Article No.8", ArticlePrice = 600 },
            new Article { ArticleId = 9, ArticleName = "Article No.9", ArticlePrice = 600 },
            new Article { ArticleId = 10, ArticleName = "Article No.10", ArticlePrice = 600 },
        };

        public static List<Customer> CustomerData = new()
        {
            new() { CustomerId = 1, CustomerName = "Customer No.1" },
            new() { CustomerId = 2, CustomerName = "Customer No.2" },
            new() { CustomerId = 3, CustomerName = "Customer No.3" },
            new() { CustomerId = 4, CustomerName = "Customer No.4" },
            new() { CustomerId = 5, CustomerName = "Customer No.5" },
            new() { CustomerId = 6, CustomerName = "Customer No.6" },
            new() { CustomerId = 7, CustomerName = "Customer No.7" },
            new() { CustomerId = 8, CustomerName = "Customer No.8" },
            new() { CustomerId = 9, CustomerName = "Customer No.9" },
            new() { CustomerId = 10, CustomerName = "Customer No.10," }
        };

        public static List<InventoryArticle> InventoryArticleData = new()
        {
            new() { InventoryArticleId = 1, ArticleId = 1, InventoryId = 1, ArticleQuantity = 500 },
            new() { InventoryArticleId = 2, ArticleId = 2, InventoryId = 2, ArticleQuantity = 300 },
            new() { InventoryArticleId = 3, ArticleId = 3, InventoryId = 3, ArticleQuantity = 200 },
            new() { InventoryArticleId = 4, ArticleId = 4, InventoryId = 4, ArticleQuantity = 700 },
            new() { InventoryArticleId = 5, ArticleId = 5, InventoryId = 5, ArticleQuantity = 2700 },
            new() { InventoryArticleId = 6, ArticleId = 6, InventoryId = 6, ArticleQuantity = 50 },
            new() { InventoryArticleId = 7, ArticleId = 7, InventoryId = 7, ArticleQuantity = 1170 },
            new() { InventoryArticleId = 8, ArticleId = 8, InventoryId = 8, ArticleQuantity = 206 },
            new() { InventoryArticleId = 9, ArticleId = 9, InventoryId = 9, ArticleQuantity = 758 },
            new() { InventoryArticleId = 10, ArticleId = 10, InventoryId = 10, ArticleQuantity = 789 },
            new() { InventoryArticleId = 11, ArticleId = 1, InventoryId = 10, ArticleQuantity = 650 },
            new() { InventoryArticleId = 12, ArticleId = 2, InventoryId = 9, ArticleQuantity = 758 },
            new() { InventoryArticleId = 13, ArticleId = 3, InventoryId = 8, ArticleQuantity = 206 },
            new() { InventoryArticleId = 14, ArticleId = 4, InventoryId = 7, ArticleQuantity = 1170 },
            new() { InventoryArticleId = 15, ArticleId = 5, InventoryId = 6, ArticleQuantity = 50 },
            new() { InventoryArticleId = 16, ArticleId = 6, InventoryId = 5, ArticleQuantity = 2700 },
            new() { InventoryArticleId = 17, ArticleId = 7, InventoryId = 4, ArticleQuantity = 332 },
            new() { InventoryArticleId = 18, ArticleId = 8, InventoryId = 3, ArticleQuantity = 77 },
            new() { InventoryArticleId = 19, ArticleId = 9, InventoryId = 2, ArticleQuantity = 10 },
            new() { InventoryArticleId = 20, ArticleId = 10, InventoryId = 1, ArticleQuantity = 0 }
        };

        public static List<Inventory> InventoryData = new()
        {
            new() { InventoryId = 1, InventoryName = "Inventory No.1" },
            new() { InventoryId = 2, InventoryName = "Inventory No.2" },
            new() { InventoryId = 3, InventoryName = "Inventory No.3" },
            new() { InventoryId = 4, InventoryName = "Inventory No.4" },
            new() { InventoryId = 5, InventoryName = "Inventory No.5" },
            new() { InventoryId = 6, InventoryName = "Inventory No.6" },
            new() { InventoryId = 7, InventoryName = "Inventory No.7" },
            new() { InventoryId = 8, InventoryName = "Inventory No.8" },
            new() { InventoryId = 9, InventoryName = "Inventory No.9" },
            new() { InventoryId = 10, InventoryName = "Inventory No.10," }
        };
    }
}
