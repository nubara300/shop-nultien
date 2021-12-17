using Microsoft.EntityFrameworkCore;
using NultienShop.DataAccess.Domain;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IDataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace NultienShop.DataAccess
{
    public class ArticleRepository : IArticleRepository
    {
        protected readonly AppDBContext _context;

        public ArticleRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Article> IsArticleValidAndInAnyInventory(int articleId, int maxPrice)
        {
            return await _context.InventoryArticle.AsNoTracking()
                .Where(x => x.ArticleId == articleId && x.Article.ArticlePrice <= maxPrice && x.ArticleQuantity > 0)
                .Include(x => x.Article).Select(x => x.Article).FirstOrDefaultAsync();
        }
    }
}