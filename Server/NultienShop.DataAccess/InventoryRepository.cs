using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NultienShop.DataAccess.Domain;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NultienShop.DataAccess
{
    public class InventoryRepository : IInventoryRepository
    {
        protected readonly AppDBContext _context;

        public InventoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryArticle>> GetArticleInventoriesByQuantity(int articleId, int quantity, int maxPrice)
        {
            var firstGreaterInventory = await _context.InventoryArticle.Where(x => x.ArticleId == articleId && x.ArticleQuantity >= quantity).FirstOrDefaultAsync();
            if (firstGreaterInventory == null)
            {
                SqlParameter param1 = new("ArticleId", articleId);
                SqlParameter param2 = new("ArticleQuantity", quantity);
                return await _context.InventoryArticle
                    .FromSqlRaw($"EXEC SelectArticleQuantity {0}, {1}", articleId, quantity)
                    .ToListAsync();
            }

            return new List<InventoryArticle> { firstGreaterInventory };
        }

        public async Task<List<Inventory>> GetInventories(int page, int size)
        {
            return await _context.Inventory.AsNoTracking()
                 .OrderByDescending(x => x.InventoryId)
                 .Skip((page - 1) * size)
                 .Take(size)
                 .ToListAsync();
        }
    }
}