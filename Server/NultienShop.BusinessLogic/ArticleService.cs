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
    public class ArticleService : IArticleService
    {
        private ILogger<ArticleService> _logger;
        private IBaseRepository _baseRepository;
        private IInventoryService _inventoryService;
        private IArticleRepository _articleRepository;

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
                    //asumption is made that the article exists
                    _baseRepository.AddOrUpdateContext(new Order(quantity, customerId, false, articleId, null));
                    await _baseRepository.SaveContextAsync();
                    response.Message = "Article not available";
                    return response;
                }

                List<InventoryArticle> inventories = await _inventoryService.GetListOfInventoriesAndSetQuantity(articleId, quantity, maxPrice);
                //update inventory count
                _baseRepository.AddOrUpdateContext(inventories);
                //creating new succsefull order
                _baseRepository.AddOrUpdateContext(new Order(quantity, customerId, true, article.ArticleId, article.ArticlePrice));
                //save changes to databse
                await _baseRepository.SaveContextAsync();
                response.IsSuccess = true;
                response.Message = "Order succesfully created!";
            }
            //reconsider custom exception
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception has occured");
                response.Errors.Add(ex.Message);
                throw;
            }

            return response;
        }

        public async Task<PaginationResponse<ArticleVM>> GetArticles(int page, int size)
        {
            List<ArticleVM> list = (await _baseRepository.GetListByFilter<Article>(x => x.IsDeleted != true)).AdaptToViewModel();
            int total = await _baseRepository.Count<Article>(x => x.IsDeleted != true);
            return new(list, total);
        }

        public async Task<Article> IsArticleInInventory(int articleId, int maxPrice)
        {
            return await _articleRepository.IsArticleValidAndInAnyInventory(articleId, maxPrice);
        }
    }
}