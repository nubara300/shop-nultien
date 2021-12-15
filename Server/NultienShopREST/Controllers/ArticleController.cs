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

        public ArticleController(ILogger<ArticleController> logger) : base(logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult PingServer()
        {
            _logger.LogInformation("Server pinged");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetOrder([FromBody] ArticleOrderVM articleOrder)
        {
            return await TryReturnOk(() =>
                _articleService.OrderArticle(articleOrder.ArticleId, articleOrder.Quantity, articleOrder.CustomerId, articleOrder.MaxPrice));
        }
    }
}