using Moq;
using NultienShop.DataAccess;
using NultienShop.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NultienShop.DataAccess.Domain.ModelConfiguration;
using NultienShop.DataAccess.Domain.Models;
using Xunit;

namespace NultienShopTEST.Repositories
{
    public class InventoryRepositoryTests
    {
        private readonly DbContextOptions<TheShopContext> _dbContextOptions;
        public TheShopContext _dbContextMock;

        public InventoryRepositoryTests()
        {
            this._dbContextOptions = new DbContextOptionsBuilder<TheShopContext>()
                .UseInMemoryDatabase(databaseName: "NultienTestDB")
                .Options;
            
            _dbContextMock = new TheShopContext(_dbContextOptions);
        }

        private InventoryRepository CreateInventoryRepository()
        {
            return new InventoryRepository(_dbContextMock);
        }

        [Fact]
        public async Task GetArticleInventoriesByQuantity_QuantityFromSingleSource_ShouldReturnArticleInventories()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            int articleId = 1;
            int quantity = 20;

            // Act
            var result = await inventoryRepository.GetArticleInventoriesByQuantity(
                articleId,
                quantity);

            // Assert
            Assert.True(result.Count > 0);
            Assert.IsType<List<InventoryArticle>>(result);
        }

        [Fact]
        public async Task GetArticleInventoriesByQuantity_QuantityFromMultipleSources_ShouldReturnArticleInventories()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            int articleId = 1;
            int quantity = 2000;

            // Act
            var result = await inventoryRepository.GetArticleInventoriesByQuantity(
                articleId,
                quantity
                );

            // Assert
            Assert.True(result.Count > 0);
            Assert.IsType<List<InventoryArticle>>(result);
        }

    }
}
