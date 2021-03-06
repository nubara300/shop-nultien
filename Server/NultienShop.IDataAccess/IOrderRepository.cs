using NultienShop.Common.ViewModels;
using System.Threading.Tasks;

namespace NultienShop.IDataAccess
{
    public interface IOrderRepository
    {
        Task<OrderMetrics> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest);
    }
}