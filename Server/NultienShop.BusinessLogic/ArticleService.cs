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
    public class ArticleService : IArticleService
    {
        private readonly ILogger<ArticleService> _logger;
        private readonly IBaseRepository _baseRepository;
        private readonly IInventoryService _inventoryService;
        private readonly IArticleRepository _articleRepository;

        public ArticleService(ILogger<ArticleService> logger, IBaseRepository baseRepository, IInventoryService inventoryService, IArticleRepository articleRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
            _inventoryService = inventoryService;
            _articleRepository = articleRepository;
        }

        public async Task<ValidationResponse> OrderArticle(int articleId, int quantity, int customerId, int maxPrice)
        {
            ValidationResponse response = new() { IsSuccess = false };
            _logger.LogInformation($"Article with id= {articleId}, and quantity={quantity} has been queried");
            try
            {
                var article = await IsArticleInInventory(articleId, maxPrice);

                if (article == null)
                {
                    await CreateOrder(new Order(quantity, customerId, false, null, null));
                    response.Message = "Article not available";
                    return response;
                }
                
                var inventories = await _inventoryService.GetListOfInventoriesAndSetQuantity(articleId, quantity, maxPrice);
                //update inventory count
                _baseRepository.AddOrUpdateContext(inventories);
                //creating new successful order
                _baseRepository.AddOrUpdateContext(new Order(quantity, customerId, true, article.ArticleId, article.ArticlePrice));
                //save changes to database
                await _baseRepository.SaveContextAsync();
                response.IsSuccess = true;
                response.Message = "Order successfully created!";
            }
            catch (CustomException ex)
            {
                await CreateOrder(new Order(quantity, customerId, false, articleId, null));
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<PaginationResponse<ArticleVM>> GetArticles(int page, int size)
        {
            var list = await _baseRepository.GetListByFilter<Article>(x => x.IsDeleted != true, new(page, size));
            var total = await _baseRepository.Count<Article>(x => x.IsDeleted != true);
            return new(list.Adapt<List<ArticleVM>>(), total);
        }

        public async Task<Article> IsArticleInInventory(int articleId, int maxPrice)
        {
            return await _articleRepository.IsArticleValidAndInAnyInventory(articleId, maxPrice);
        }

        private async Task CreateOrder(Order order)
        {
            if (order != null)
            {
                _baseRepository.AddOrUpdateContext(order);
                await _baseRepository.SaveContextAsync();
            }

        }
    }
}