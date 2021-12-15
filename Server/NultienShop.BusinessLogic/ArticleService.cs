using Microsoft.EntityFrameworkCore;
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
    internal class ArticleService : IArticleService
    {
        private ILogger<ArticleService> _logger;
        private IBaseRepository _baseRepository;
        private IInventoryService _inventoryService;

        public ArticleService(ILogger<ArticleService> logger, IBaseRepository baseRepository, IInventoryService inventoryService)
        {
            _logger = logger;
            _baseRepository = baseRepository;
            _inventoryService = inventoryService;
        }

        public async Task<ValidationResponse> OrderArticle(int articleId, int quantity, int customerId, int maxPrice)
        {
            ValidationResponse response = new() { IsSuccess = false };
            _logger.LogInformation($"Article with id= {articleId}, and quantity={quantity} has been queried");
            if (!(await IsArticleInInventory(articleId, maxPrice)))
            {
                response.Message = "Article not available";
                return response;
            }
            List<InventoryArticle> inventories = await _inventoryService.GetListOfInventoriesAndSetQuantity(articleId, quantity, maxPrice);
            if (inventories.Count > 0)
            {
                var article = await _baseRepository.GetByFilter<Article>(x => x.ArticleId == articleId);
                var order = new Order(quantity, customerId, articleId, article.ArticlePrice);

                await _baseRepository.GetExecutionStrategy().ExecuteAsync(async () =>
                {
                    _baseRepository.AddOrUpdateContext(inventories);
                    _baseRepository.AddOrUpdateContext(order);

                    await _baseRepository.SaveContextWithTransaction();
                });
            }

            return response;
        }

        public async Task<ArticleVM> GetArticles(int page, int size)
        {
            //return await _baseRepository.GetListByFilter<Article>(x => x.IsDeleted != true);
            return new();
        }

        public async Task<bool> IsArticleInInventory(int articleId, int maxPrice)
        {
            return await _inventoryService.IsArticleInAnyInventory(articleId, maxPrice);
        }

        Task<CustomerVM> IArticleService.GetArticles(int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}