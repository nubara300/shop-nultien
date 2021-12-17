using NultienShop.Common.ViewModels;
using System.Threading.Tasks;

namespace NultienShop.IBusinessLogic
{
    public interface IOrderService
    {
        Task<OrderMetrics> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest);
    }
}