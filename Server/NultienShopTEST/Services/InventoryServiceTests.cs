using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.BusinessLogic;
using NultienShop.Common.ViewModels;
using NultienShop.Common.ViewModels.Helpers;
using NultienShop.DataAccess.Domain.ModelConfiguration;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NultienShopTEST.Services
{
    public class InventoryServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<InventoryService>> _mockLogger;
        private Mock<IBaseRepository> _mockBaseRepository;
        private Mock<IInventoryRepository> _mockInventoryRepository;
        private readonly int _anyInt = It.IsAny<int>();

        public InventoryServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this._mockLogger = this.mockRepository.Create<ILogger<InventoryService>>();
            this._mockBaseRepository = this.mockRepository.Create<IBaseRepository>();
            this._mockInventoryRepository = this.mockRepository.Create<IInventoryRepository>();
        }

        private InventoryService CreateService()
        {
            return new InventoryService(
                this._mockLogger.Object,
                this._mockBaseRepository.Object,
                this._mockInventoryRepository.Object);
        }

        [Fact]
        public async Task GetInventories_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.GetInventories(
                _anyInt,
                _anyInt);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaginationResponse<InventoryVM>>(result);
        }

        [Fact]
        public async Task GetListOfInventoriesAndSetQuantity_ShouldReturnInventoryArticleNewValues()
        {
            // Arrange
            var service = this.CreateService();
            int articleId = 1;
            int quantity = 350;
            int maxPrice = 500;

            _mockInventoryRepository.Setup(x =>
                x.GetArticleInventoriesByQuantity(articleId, quantity))
                .ReturnsAsync(InitialData.InventoryArticleData.Where(x => x.ArticleId == 1).ToList());

            // Act
            var result = await service.GetListOfInventoriesAndSetQuantity(
                articleId,
                quantity,
                maxPrice);

            // Assert
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void GetListOfInventoriesAndSetQuantity_ShouldThrowCustomExceptionIfNoneListFound()
        {
            // Arrange
            var service = this.CreateService();

            _mockInventoryRepository.Setup(x =>
                    x.GetArticleInventoriesByQuantity(_anyInt, _anyInt))
                .ReturnsAsync(new List<InventoryArticle>());

            // Act
            var result = service.GetListOfInventoriesAndSetQuantity(
                _anyInt,
                _anyInt,
                _anyInt);

            // Assert
            Assert.ThrowsAsync<CustomException>(() => result);
        }

        [Fact]
        public async Task UpdateInventory_CreateNewInventory_ShouldReturnValidationResponseTrue()
        {
            // Arrange
            var service = this.CreateService();
            InventoryVM inventoryVM = new()
            {
                InventoryId = 0,
                ArticleId = 1,
                ArticleQuantity = 50,
                InventoryName = "Name"
            };

            // Act
            var result = await service.UpdateInventory(
                inventoryVM);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateInventory_UpdateExistingInventory_ShouldReturnValidationResponseTrue()
        {
            // Arrange
            var service = this.CreateService();
            InventoryVM inventoryVM = new()
            {
                ArticleId = 1,
                InventoryId = 1,
                ArticleQuantity = 500
            };

            _mockBaseRepository.Setup(x =>
                    x.GetByFilter<Inventory>(x => x.InventoryId == inventoryVM.InventoryId))
                .ReturnsAsync(new Inventory() { InventoryId = 1 });

            _mockBaseRepository.Setup(x =>
                    x.GetByFilter<InventoryArticle>(x => x.InventoryId == inventoryVM.InventoryId))
                .ReturnsAsync(new InventoryArticle() { InventoryId = 1, ArticleId = 1 });

            // Act
            var result = await service.UpdateInventory(
                inventoryVM);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}