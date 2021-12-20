using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.IBusinessLogic;
using NultienShopREST.Controllers;
using System.Threading.Tasks;
using NultienShop.Common.ViewModels;
using NultienShopTEST.helpers;
using Xunit;

namespace NultienShopTEST.Controllers
{
    public class OrderControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<OrderController>> mockLogger;
        private Mock<IOrderService> mockOrderService;

        public OrderControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockLogger = this.mockRepository.Create<ILogger<OrderController>>();
            this.mockOrderService = this.mockRepository.Create<IOrderService>();
        }

        private OrderController CreateOrderController()
        {
            return new OrderController(
                this.mockLogger.Object,
                this.mockOrderService.Object);
        }

        [Fact]
        public async Task GetOrderMetrics_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var orderController = this.CreateOrderController();

            // Act
            var result = await orderController.GetOrderMetrics(
                It.IsAny<OrderMetricsRequest>());

            // Assert
            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(200, statusCode);
        }
    }
}
