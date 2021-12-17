using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NultienShop.IBusinessLogic
{
    public interface IInventoryService
    {
        Task<List<InventoryArticle>> GetListOfInventoriesAndSetQuantity(int articleId, int quantity, int maxPrice);

        Task<PaginationResponse<InventoryVM>> GetInventories(int page, int size);

        Task<ValidationResponse> UpdateInventory(InventoryVM inventory);
    }
}