using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.IBusinessLogic;
using NultienShopREST.Controllers;
using System;
using System.Threading.Tasks;
using NultienShop.Common.ViewModels;
using NultienShopTEST.helpers;
using Xunit;

namespace NultienShopTEST.Controllers
{
    public class InventoryControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<InventoryController>> mockLogger;
        private Mock<IInventoryService> mockInventoryService;

        public InventoryControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockLogger = this.mockRepository.Create<ILogger<InventoryController>>();
            this.mockInventoryService = this.mockRepository.Create<IInventoryService>();
        }

        private InventoryController CreateInventoryController()
        {
            return new InventoryController(
                this.mockLogger.Object,
                this.mockInventoryService.Object);
        }

        [Fact]
        public async Task GetInventory_GetInventoryPagination_ShouldReturnOk()
        {
            // Arrange
            var inventoryController = this.CreateInventoryController();

            // Act
            var result = await inventoryController.GetInventory(
                It.IsAny<int>(),
                It.IsAny<int>());

            // Assert
            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task UpdateInventory_ForAnyModel_ShouldReturnOk()
        {
            // Arrange
            var inventoryController = this.CreateInventoryController();

            // Act
            var result = await inventoryController.UpdateInventory(
                It.IsAny<InventoryVM>());

            // Assert
            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(200, statusCode);
        }
    }
}
