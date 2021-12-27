using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NultienShop.DataAccess.Domain;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NultienShop.DataAccess
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly TheShopContext _context;
        private readonly IConfiguration _configuration;


        public InventoryRepository(TheShopContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<InventoryArticle>> GetArticleInventoriesByQuantity(int articleId, int quantity)
        {
            var firstGreaterInventory = await _context.InventoryArticle.Where(x => x.ArticleId == articleId && x.ArticleQuantity >= quantity).FirstOrDefaultAsync();
            if (firstGreaterInventory == null)
            {
                _ = bool.TryParse(_configuration.GetSection("useInMemoryDatabase").Value, out bool useInMemoryDatabase);
                if (useInMemoryDatabase)
                {
                    return await _context.InventoryArticle
                        .Where(x => x.ArticleId == articleId)
                        .ToListAsync();
                }
                var articleIdParam = new SqlParameter("@ArticleId", articleId);
                var articleQuantityParam = new SqlParameter("@ArticleQuantity", quantity);

                return await _context.InventoryArticle
                    .FromSqlRaw($"EXEC SelectArticleQuantity @ArticleId,@ArticleQuantity ", articleIdParam, articleQuantityParam)
                    .ToListAsync();
            }

            return new List<InventoryArticle> { firstGreaterInventory };
        }

    }
}