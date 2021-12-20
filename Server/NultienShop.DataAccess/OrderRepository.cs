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
        private readonly TheShopContext _context;

        public OrderRepository(TheShopContext context)
        {
            _context = context;
        }

        public async Task<OrderMetrics> GetOrderMetrics(OrderMetricsRequest orderMetricsRequest)
        {
            var query = _context.ArticleOrder.AsNoTracking().AsQueryable();
            if (orderMetricsRequest.ArticleId > 0)
            {
                query = query.Where(x => x.ArticleId == orderMetricsRequest.ArticleId);
            }
            if (orderMetricsRequest.CustomerId > 0)
            {
                query = query.Where(x => x.Order.CustomerId == orderMetricsRequest.CustomerId);
            }
            if (orderMetricsRequest.DateTo.HasValue)
            {
                query = query.Where(x => x.Order.DateCreated.CompareTo(orderMetricsRequest.DateTo.Value) <= 0);
            }
            if (orderMetricsRequest.DateFrom.HasValue)
            {
                query = query.Where(x => x.Order.DateCreated.CompareTo(orderMetricsRequest.DateFrom.Value) >= 0);
            }
            var successful = await query.Where(x => x.Order.Completed == true).Select(x => x.Order).CountAsync();
            var failed = await query.Where(x => x.Order.Completed != true).Select(x => x.Order).CountAsync();

            return new (successful, failed);
        }
    }
}