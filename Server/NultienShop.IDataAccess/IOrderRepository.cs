using NultienShop.Common.ViewModels;
using System.Threading.Tasks;

namespace NultienShop.IDataAccess
{
    public interface IOrderRepository
    {
        Task<(int succsefull, int failed)> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest);
    }
}