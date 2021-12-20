using Microsoft.Extensions.Logging;
using Moq;
using NultienShop.BusinessLogic;
using NultienShop.Common.ViewModels;
using NultienShop.Common.ViewModels.Helpers;
using NultienShop.DataAccess.Domain.ModelConfiguration;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System.Threading.Tasks;
using Xunit;

namespace NultienShopTEST.Services
{
    public class ArticleServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<ArticleService>> _mockLogger;
        private Mock<IBaseRepository> _mockBaseRepository;
        private Mock<IInventoryService> _mockInventoryService;
        private Mock<IArticleRepository> _mockArticleRepository;
        private readonly int _anyInt = It.IsAny<int>();

        public ArticleServiceTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Default);

            this._mockLogger = this._mockRepository.Create<ILogger<ArticleService>>();
            this._mockBaseRepository = this._mockRepository.Create<IBaseRepository>();
            this._mockInventoryService = this._mockRepository.Create<IInventoryService>();
            this._mockArticleRepository = this._mockRepository.Create<IArticleRepository>();
        }

        private ArticleService CreateService()
        {
            return new ArticleService(
                this._mockLogger.Object,
                this._mockBaseRepository.Object,
                this._mockInventoryService.Object,
                this._mockArticleRepository.Object);
        }

        [Fact]
        public async Task OrderArticle_ArticleAvailableAndHasQuantity_OrderSuccessful()
        {
            // Arrange
            var service = this.CreateService();

            _mockArticleRepository.Setup(x =>
                    x.IsArticleValidAndInAnyInventory(_anyInt, _anyInt))
                .ReturnsAsync(new Article() { ArticleId = 1, ArticleName = "Article for test" });

            _mockInventoryService.Setup(x =>
                    x.GetListOfInventoriesAndSetQuantity(_anyInt, _anyInt, _anyInt))
                .ReturnsAsync(InitialData.InventoryArticleData);

            // Act
            var result = await service.OrderArticle(
                _anyInt,
                _anyInt,
                _anyInt,
                _anyInt);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task OrderArticle_ArticleNotFound_ShouldReturnFalseWhenNoArticle()
        {
            // Arrange
            var service = this.CreateService();

            _mockArticleRepository.Setup(x =>
                    x.IsArticleValidAndInAnyInventory(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await service.OrderArticle(
                _anyInt,
                _anyInt,
                _anyInt,
                _anyInt);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task OrderArticle_NoArticleQuantity_ShouldReturnFalseAndMessageWhenNoInventory()
        {
            // Arrange
            var service = this.CreateService();

            _mockArticleRepository.Setup(x =>
                    x.IsArticleValidAndInAnyInventory(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new Article() { ArticleId = 1, ArticleName = "Article one" });

            var errorMessage = "No inventory";
            _mockInventoryService.Setup(x =>
                    x.GetListOfInventoriesAndSetQuantity(_anyInt, _anyInt, _anyInt))
                .Throws(new CustomException(errorMessage));

            var result = await service.OrderArticle(
                _anyInt,
                _anyInt,
                _anyInt,
                _anyInt);

            Assert.False(result.IsSuccess);
            Assert.Equal(result.Message, errorMessage);
        }

        [Fact]
        public async Task GetArticles_ShouldReturnArticleList()
        {
            // Arrange
            var service = this.CreateService();

            _mockBaseRepository.Setup(x =>
                    x.GetListByFilter<Article>(x => x.IsDeleted != true, new(0, 10)))
                .ReturnsAsync(InitialData.ArticleData);

            // Act
            var result = await service.GetArticles(
                0,
                10);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaginationResponse<ArticleVM>>(result);
        }

        [Fact]
        public async Task IsArticleInInventory_ArticleIsFound_ShouldReturnArticle()
        {
            // Arrange
            var service = this.CreateService();
            _mockArticleRepository.Setup(x =>
                    x.IsArticleValidAndInAnyInventory(_anyInt, _anyInt))
                .ReturnsAsync(new Article() { ArticleId = 1, ArticleName = "Test" });

            // Act
            var result = await service.IsArticleInInventory(_anyInt, _anyInt);

            // Assert
            Assert.IsType<Article>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task IsArticleInInventory_ArticleIsNotFound_ShouldReturnNull()
        {
            // Arrange
            var service = this.CreateService();
            _mockArticleRepository.Setup(x =>
                    x.IsArticleValidAndInAnyInventory(_anyInt, _anyInt))
                .ReturnsAsync(() => null);

            // Act
            var result = await service.IsArticleInInventory(_anyInt, _anyInt);

            // Assert
            Assert.Null(result);
        }
    }
}