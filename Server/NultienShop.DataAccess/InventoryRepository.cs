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
            var query = _context.InventoryArticle.Where(x => x.ArticleId == articleId && x.Article.ArticlePrice <= maxPrice);
            var firstGreaterInventory = query.Where(x => x.ArticleQuantity >= quantity).FirstOrDefault();

            return firstGreaterInventory != null ?
            new List<InventoryArticle> { firstGreaterInventory } : await query.Where(x => x.ArticleQuantity <= quantity).ToListAsync();
        }
    }
}