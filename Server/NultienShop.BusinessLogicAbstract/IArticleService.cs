using NultienShop.Common.ViewModels;
using System.Threading.Tasks;

namespace NultienShop.IBusinessLogic
{
    public interface IArticleService
    {
        Task<ValidationResponse> OrderArticle(int articleId, int quantity, int customerId, int maxPrice);

        Task<bool> IsArticleInInventory(int articleId, int maxPrice);

        Task<CustomerVM> GetArticles(int page, int size);
    }
}