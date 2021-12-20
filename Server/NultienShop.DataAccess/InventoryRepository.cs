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
        private readonly TheShopContext _context;

        public InventoryRepository(TheShopContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryArticle>> GetArticleInventoriesByQuantity(int articleId, int quantity)
        {
            var firstGreaterInventory = await _context.InventoryArticle.Where(x => x.ArticleId == articleId && x.ArticleQuantity >= quantity).FirstOrDefaultAsync();
            if (firstGreaterInventory == null)
            {
                return await _context.InventoryArticle
                    .FromSqlRaw($"EXEC SelectArticleQuantity {0}, {1}", articleId, quantity)
                    .ToListAsync();
            }

            return new List<InventoryArticle> { firstGreaterInventory };
        }
        
    }
}