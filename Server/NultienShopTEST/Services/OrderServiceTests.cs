using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.BusinessLogic;
using NultienShop.Common.ViewModels;
using NultienShop.IDataAccess;
using System.Threading.Tasks;
using Xunit;

namespace NultienShopTEST.Services
{
    public class OrderServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<CustomerService>> _mockLogger;
        private Mock<IOrderRepository> _mockOrderRepository;

        public OrderServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this._mockLogger = this.mockRepository.Create<ILogger<CustomerService>>();
            this._mockOrderRepository = this.mockRepository.Create<IOrderRepository>();
        }

        private OrderService CreateService()
        {
            return new OrderService(
                this._mockLogger.Object,
                this._mockOrderRepository.Object);
        }

        [Fact]
        public async Task GetOrderMetrics_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var request = It.IsAny<OrderMetricsRequest>();
            OrderMetrics orderMetrics = new()
            {
                UnsuccessfulOrders = 5,
                SuccessfulOrders = 10
            };

            _mockOrderRepository.Setup(x => x.GetOrderMetrics(request))
                .ReturnsAsync(orderMetrics);

            var service = this.CreateService();

            // Act
            var result = await service.GetOrderMetrics(
                request);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderMetrics>(result);
        }
    }
}