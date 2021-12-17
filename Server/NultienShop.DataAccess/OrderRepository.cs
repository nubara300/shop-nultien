using Microsoft.EntityFrameworkCore;
using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain;
using NultienShop.IDataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace NultienShop.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly AppDBContext _context;

        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<(int succsefull, int failed)> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest)
        {
            var queery = _context.ArticleOrder.AsNoTracking().AsQueryable();
            if (orderMetricsRequest.ArticleId > 0)
            {
                queery = queery.Where(x => x.ArticleId == orderMetricsRequest.ArticleId);
            }
            if (orderMetricsRequest.CustomerId > 0)
            {
                queery = queery.Where(x => x.Order.CustomerId == orderMetricsRequest.CustomerId);
            }
            if (orderMetricsRequest.DateTo.HasValue)
            {
                queery = queery.Where(x => x.Order.DateCreated.CompareTo(orderMetricsRequest.DateTo.Value) <= 0);
            }
            if (orderMetricsRequest.DateFrom.HasValue)
            {
                queery = queery.Where(x => x.Order.DateCreated.CompareTo(orderMetricsRequest.DateFrom.Value) >= 0);
            }
            var succsefull = await queery.Where(x => x.Order.Completed == true).Select(x => x.Order).CountAsync();
            var failed = await queery.Where(x => x.Order.Completed != true).Select(x => x.Order).CountAsync();

            return (succsefull, failed);
        }
    }
}