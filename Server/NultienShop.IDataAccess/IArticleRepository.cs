using NultienShop.DataAccess.Domain.Models;
using System.Threading.Tasks;

namespace NultienShop.IDataAccess
{
    public interface IArticleRepository
    {
        Task<Article> IsArticleValidAndInAnyInventory(int articleId, int maxPrice);
    }
}