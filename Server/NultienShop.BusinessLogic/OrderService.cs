using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System.Threading.Tasks;

namespace NultienShop.BusinessLogic
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderService(ILogger<CustomerService> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<OrderMetrics> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest)
        {
            return await _orderRepository.GetOrderMetrics(orderMetricsRequest);
        }
    }
}