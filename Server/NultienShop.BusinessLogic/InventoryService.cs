using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NultienShop.BusinessLogic
{
    public class InventoryService : IInventoryService
    {
        private ILogger<InventoryService> _logger;
        private IBaseRepository _baseRepository;
        private IInventoryRepository _inventoryRepository;

        public InventoryService(ILogger<InventoryService> logger, IBaseRepository baseRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
        }

        public async Task<List<InventoryVM>> GetInventories(int page, int size)
        {
            //await _baseRepository.GetListByFilter()
            return new List<InventoryVM>();
        }

        public async Task<List<InventoryArticle>> GetListOfInventoriesAndSetQuantity(int articleId, int quantity, int maxPrice)
        {
            var inventoryArticles = await _inventoryRepository.GetArticleInventoriesByQuantity(articleId, quantity, maxPrice);
            int difference = 0;
            int quantityToRemove = quantity;
            for (int i = 0; i < inventoryArticles.Count; i++)
            {
                difference = inventoryArticles[i].ArticleQuantity - quantityToRemove;
                inventoryArticles[i].ArticleQuantity = difference > 0 ? difference : 0;
                if (difference > 0) break;
                quantityToRemove -= difference;
            }
            if (difference < 0)
            {
                throw new Exception($"Required number of articles({quantity}) excedes the limit of available articles.");
            }
            return inventoryArticles;
        }

        public async Task<bool> IsArticleInAnyInventory(int articleId, int maxPrice)
        {
            return await _baseRepository.Any<InventoryArticle>(x => x.ArticleId == articleId && x.Article.ArticlePrice <= maxPrice);
        }

        public Task<ValidationResponse> UpdateInventory(InventoryVM inventory)
        {
            throw new NotImplementedException();
        }
    }
}