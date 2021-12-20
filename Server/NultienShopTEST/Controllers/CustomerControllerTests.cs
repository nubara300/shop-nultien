using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using NultienShopREST.Controllers;
using NultienShopTEST.helpers;
using System.Threading.Tasks;
using Xunit;

namespace NultienShopTEST.Controllers
{
    public class CustomerControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<CustomerController>> _mockLogger;
        private Mock<ICustomerService> _mockCustomerService;

        public CustomerControllerTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Default);

            this._mockLogger = this._mockRepository.Create<ILogger<CustomerController>>();
            this._mockCustomerService = this._mockRepository.Create<ICustomerService>();
        }

        private CustomerController CreateCustomerController()
        {
            return new CustomerController(
                this._mockLogger.Object,
                this._mockCustomerService.Object);
        }

        [Fact]
        public async Task GetCustomers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var customerController = this.CreateCustomerController();
            int page = 0;
            int size = 10;

            // Act
            var result = await customerController.GetCustomers(
                page,
                size);

            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task UpdateCustomer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var customerController = this.CreateCustomerController();
            CustomerVM customer = new()
            {
                CustomerEmail = "CustomerEmail@email.com",
                CustomerId = 1,
                CustomerName = "Customer Name"
            };

            // Act
            var result = await customerController.UpdateCustomer(
                customer);

            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(200, statusCode);
        }
    }
}