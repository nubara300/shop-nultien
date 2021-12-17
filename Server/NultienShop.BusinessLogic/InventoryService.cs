using Microsoft.Extensions.Logging;
using NultienShop.BusinessLogic.Mappers;
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

        public InventoryService(ILogger<InventoryService> logger, IBaseRepository baseRepository, IInventoryRepository inventoryRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<PaginationResponse<InventoryVM>> GetInventories(int page, int size)
        {
            var list = await _inventoryRepository.GetInventories(page, size);
            var total = await _baseRepository.Count<Inventory>(x => true);
            return new(new(), total);
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
            if (difference < 0 || inventoryArticles.Count == 0)
            {
                var message = $"Required number of articles({quantity}) excedes the limit of available articles in all inventories.";
                _logger.LogError(message);
                throw new Exception(message);
            }
            return inventoryArticles;
        }

        public async Task<ValidationResponse> UpdateInventory(InventoryVM inventoryVM)
        {
            ValidationResponse validationResponse = new() { IsSuccess = false };
            Inventory inventory = new();
            InventoryArticle inventoryArticle = new();
            if (inventoryVM.InventoryId > 0)
            {
                inventory = await _baseRepository.GetByFilter<Inventory>(x => x.InventoryId == inventoryVM.InventoryId);
                if (inventory == null)
                {
                    validationResponse.Message = "Inventory not found";
                    return validationResponse;
                }

                inventory.InventoryName = inventoryVM.InventoryName;

                inventoryArticle = await _baseRepository
                    .GetByFilter<InventoryArticle>(x => x.InventoryId == inventory.InventoryId && inventoryVM.ArticleId == x.ArticleId);

                if (inventoryArticle == null)
                {
                    validationResponse.Errors.Add("Inventory updated but no article added to it");
                }
                else
                {
                    inventoryArticle.ArticleQuantity = inventoryVM.ArticlQuantity;
                }
                _baseRepository.AddOrUpdateContext(inventory);
                _baseRepository.AddOrUpdateContext(inventoryArticle);
                await _baseRepository.SaveContextAsync();
            }
            else
            {
                inventory = inventoryVM.AdaptToModel();
                inventory.InventoryArticles.Add(new() { ArticleId = inventoryVM.ArticleId, ArticleQuantity = inventoryVM.ArticlQuantity, InventoryId = inventory.InventoryId });
                _baseRepository.AddOrUpdateContext(inventory);
                await _baseRepository.SaveContextAsync();
            }

            validationResponse.IsSuccess = true;
            validationResponse.Message = "Succsefull update";
            return validationResponse;
        }
    }
}