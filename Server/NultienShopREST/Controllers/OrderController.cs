using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using System.Threading.Tasks;

namespace NultienShopREST.Controllers
{
    public class OrderController : BaseController
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService) : base(logger)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        [Route("get-order-metrics")]
        public async Task<IActionResult> GetOrderMetrics([FromBody] OrderMetricsRequest orderMetricsRequest)
        {
            _logger.LogInformation("Order metrics are requested");
            return await TryReturnOk(() => _orderService.GetOrderMetrics(orderMetricsRequest));
        }
    }
}