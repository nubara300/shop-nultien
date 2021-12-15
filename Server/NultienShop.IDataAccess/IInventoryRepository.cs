using NultienShop.DataAccess.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NultienShop.IDataAccess
{
    public interface IInventoryRepository
    {
        Task<List<InventoryArticle>> GetArticleInventoriesByQuantity(int articleId, int quantity, int maxPrice);
    }
}