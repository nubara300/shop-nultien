using Moq;
using NultienShop.DataAccess;
using NultienShop.DataAccess.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NultienShop.DataAccess.Domain.Models;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace NultienShopTEST.Repositories
{
    public class InventoryRepositoryTests
    {
        private MockRepository mockRepository;
        private readonly DbContextOptions<TheShopContext> _dbContextOptions;
        public TheShopContext _dbContextMock;
        private Mock<IConfiguration> mockConfiguration;

        public InventoryRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockConfiguration = this.mockRepository.Create<IConfiguration>();

            Mock<IConfigurationSection> mockSection = this.mockRepository.Create<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns("false");

            mockConfiguration.Setup(x => x.GetSection(It.Is<string>(k => k == "useInMemoryDatabase"))).Returns(mockSection.Object);

            this._dbContextOptions = new DbContextOptionsBuilder<TheShopContext>()
                .UseInMemoryDatabase(databaseName: "NultienTestDB")
                .Options;

            _dbContextMock = new TheShopContext(_dbContextOptions);
        }

        private InventoryRepository CreateInventoryRepository()
        {
            return new InventoryRepository(_dbContextMock, mockConfiguration.Object);
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
