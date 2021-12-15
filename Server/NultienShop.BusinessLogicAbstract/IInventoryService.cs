using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NultienShop.IBusinessLogic
{
    public interface IInventoryService
    {
        Task<List<InventoryArticle>> GetListOfInventoriesAndSetQuantity(int articleId, int quantity, int maxPrice);

        Task<bool> IsArticleInAnyInventory(int articleId, int maxPrice);

        Task<List<InventoryVM>> GetInventories(int page, int size);

        Task<ValidationResponse> UpdateInventory(InventoryVM inventory);
    }
}