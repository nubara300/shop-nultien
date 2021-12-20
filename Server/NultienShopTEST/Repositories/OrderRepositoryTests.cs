using Moq;
using NultienShop.DataAccess;
using NultienShop.DataAccess.Domain;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NultienShop.Common.ViewModels;
using Xunit;
using NultienShop.DataAccess.Domain.ModelConfiguration;
using NultienShop.DataAccess.Domain.Models;

namespace NultienShopTEST.Repositories
{
    public class OrderRepositoryTests
    {
        private readonly DbContextOptions<AppDBContext> _dbContextOptions;
        public AppDBContext _dbContextMock;

        public OrderRepositoryTests()
        {
            this._dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "NultienTestDB")
                .Options;
            _dbContextMock = new AppDBContext(_dbContextOptions);
            _dbContextMock.Order.AddRange(new Order(10, 1, true, 1, 1000),
                new Order(66, 1, false, 1, 1800),
                new Order(700, 1, true, 1, 1400));
            _dbContextMock.SaveChanges();
        }

        private OrderRepository CreateOrderRepository()
        {
            return new OrderRepository(_dbContextMock);
        }

        [Fact]
        public async Task GetOrderMetrics_ShouldReturnOrderMetrics()
        {
            // Arrange
            var orderRepository = this.CreateOrderRepository();
            OrderMetricsRequest orderMetricsRequest = new OrderMetricsRequest()
            {
                ArticleId = 1
            };

            // Act
            var result = await orderRepository.GetOrderMetrics(
                orderMetricsRequest);

            // Assert
            Assert.IsType<OrderMetrics>(result);
            Assert.True(result.SuccessfulOrders > 0);
        }
    }
}
