using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.BusinessLogic;
using NultienShop.Common.ViewModels;
using NultienShop.IDataAccess;
using System.Threading.Tasks;
using Xunit;

namespace NultienShopTEST.Services
{
    public class CustomerServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<CustomerService>> _mockLogger;
        private Mock<IBaseRepository> _mockBaseRepository;

        public CustomerServiceTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Default);

            this._mockLogger = this._mockRepository.Create<ILogger<CustomerService>>();
            this._mockBaseRepository = this._mockRepository.Create<IBaseRepository>();
        }

        private CustomerService CreateService()
        {
            return new CustomerService(
                this._mockLogger.Object,
                this._mockBaseRepository.Object);
        }

        [Fact]
        public async Task GetCustomers_ShouldGetCustomerList()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.GetCustomers(
                It.IsAny<int>(),
                It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaginationResponse<CustomerVM>>(result);
        }

        [Fact]
        public async Task UpdateCustomer_AddCustomer_CustomerIsAddedAndSuccessIsReturned()
        {
            // Arrange
            var service = this.CreateService();
            CustomerVM customerVM = new()
            {
                CustomerId = 1,
                CustomerName = "Test"
            };

            // Act
            var result = await service.UpdateCustomer(
                customerVM);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}