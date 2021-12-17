using Microsoft.Extensions.Logging;
using NultienShop.BusinessLogic.Mappers;
using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System.Threading.Tasks;

namespace NultienShop.BusinessLogic
{
    public class OrderService : IOrderService
    {
        private ILogger<CustomerService> _logger;
        private IOrderRepository _orderRepository;

        public OrderService(ILogger<CustomerService> logger, IBaseRepository baseRepository, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<OrderMetrics> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest)
        {
            (int succsefull, int failed) = await _orderRepository.GetOrderMetrics(orderMetricsRequest);
            return new() { SuccsefullOrders = succsefull, UnsucsefullOrders = failed };
        }
    }
}