using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using NultienShopREST.Controllers;
using NultienShopTEST.helpers;
using System.Threading.Tasks;
using Xunit;

namespace NultienShopTEST.Controllers
{
    public class ArticleControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<ArticleController>> _mockLogger;
        private Mock<IArticleService> _mockArticleService;

        public ArticleControllerTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Default);

            this._mockLogger = this._mockRepository.Create<ILogger<ArticleController>>();
            this._mockArticleService = this._mockRepository.Create<IArticleService>();
        }

        private ArticleController CreateArticleController()
        {
            return new ArticleController(
                this._mockLogger.Object,
                this._mockArticleService.Object);
        }

        [Fact]
        public async Task GetArticles_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var articleController = this.CreateArticleController();
            int page = 0;
            int pageSize = 10;

            // Act
            var result = await articleController.GetArticles(
                page,
                pageSize);

            var getObjectResult = result as ObjectResult;
            // Assert
            Assert.Equal(200, getObjectResult.StatusCode);
        }

        [Fact]
        public async Task OrderArticle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var articleController = this.CreateArticleController();
            ArticleOrderRequest articleOrder = new()
            {
                ArticleId = 1,
                CustomerId = 1,
                MaxPrice = 1000,
                Quantity = 500
            };

            // Act
            var result = await articleController.OrderArticle(
                articleOrder);

            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task OrderArticle_StateUnderTest_ExpectedError()
        {
            // Arrange
            var articleController = this.CreateArticleController();
            ArticleOrderRequest articleOrder = null;

            // Act
            var result = await articleController.OrderArticle(
                articleOrder);
            var statusCode = TestHelper.GetObjectStatusResult(result);
            // Assert
            Assert.Equal(500, statusCode);
        }
    }
}