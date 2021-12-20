using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using NultienShop.Common.ViewModels.Helpers;

namespace NultienShop.BusinessLogic
{
    public class InventoryService : IInventoryService
    {
        private readonly ILogger<InventoryService> _logger;
        private readonly IBaseRepository _baseRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(ILogger<InventoryService> logger, IBaseRepository baseRepository, IInventoryRepository inventoryRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<PaginationResponse<InventoryVM>> GetInventories(int page, int size)
        {
            var list = await _baseRepository.GetListByFilter<Inventory>(x=>x.IsDeleted!=true, new(page,size));
            var total = await _baseRepository.Count<Inventory>(x => true);
            return new(list.Adapt<List<InventoryVM>>(), total);
        }

        public async Task<List<InventoryArticle>> GetListOfInventoriesAndSetQuantity(int articleId, int quantity, int maxPrice)
        {
            var inventoryArticles = await _inventoryRepository.GetArticleInventoriesByQuantity(articleId, quantity);
            var difference = 0;
            var quantityToRemove = quantity;
            foreach (var t in inventoryArticles)
            {
                difference = t.ArticleQuantity - quantityToRemove;
                t.ArticleQuantity = difference > 0 ? difference : 0;
                if (difference > 0) break;
                quantityToRemove -= difference;
            }
            if (difference < 0 || inventoryArticles.Count == 0)
            {
                var message = $"Required number of articles({quantity}) exceeds the limit of available articles in all inventories.";
                _logger.LogError(message);
                throw new CustomException(message);
            }
            return inventoryArticles;
        }

        public async Task<ValidationResponse> UpdateInventory(InventoryVM inventoryVM)
        {
            ValidationResponse validationResponse = new() { IsSuccess = false };
            Inventory inventory;
            if (inventoryVM.InventoryId > 0)
            {
                inventory = await _baseRepository.GetByFilter<Inventory>(x => x.InventoryId == inventoryVM.InventoryId);
                if (inventory == null)
                {
                    validationResponse.Message = "Inventory not found";
                    return validationResponse;
                }

                inventory.InventoryName = inventoryVM.InventoryName;

                var inventoryArticle = await _baseRepository
                    .GetByFilter<InventoryArticle>(x => x.InventoryId == inventory.InventoryId && inventoryVM.ArticleId == x.ArticleId);

                if (inventoryArticle == null)
                {
                    validationResponse.Errors.Add("Inventory updated but no article added to it");
                }
                else
                {
                    inventoryArticle.ArticleQuantity = inventoryVM.ArticleQuantity;
                    _baseRepository.AddOrUpdateContext(inventoryArticle);
                }

                _baseRepository.AddOrUpdateContext(inventory);
                await _baseRepository.SaveContextAsync();
            }
            else
            {
                //add validation for inventory data
                inventory = inventoryVM.Adapt<Inventory>();
                inventory.InventoryArticles.Add(new() { ArticleId = inventoryVM.ArticleId, ArticleQuantity = inventoryVM.ArticleQuantity, InventoryId = inventory.InventoryId });
                _baseRepository.AddOrUpdateContext(inventory);
                await _baseRepository.SaveContextAsync();
            }

            validationResponse.IsSuccess = true;
            validationResponse.Message = "Successful update";
            return validationResponse;
        }
    }
}