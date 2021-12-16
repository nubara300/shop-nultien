using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using System.Threading.Tasks;

namespace NultienShopREST.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IArticleService _articleService;

        public ArticleController(ILogger<ArticleController> logger, IArticleService articleService) : base(logger)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles(int page = 0, int pageSize = 10)
        {
            return await TryReturnOk(() => _articleService.GetArticles(page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> OrderArticle([FromBody] ArticleOrderVM articleOrder)
        {
            return await TryReturnOk(() =>
                _articleService.OrderArticle(articleOrder.ArticleId, articleOrder.Quantity, articleOrder.CustomerId, articleOrder.MaxPrice));
        }


    }
}