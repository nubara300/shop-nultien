using Microsoft.EntityFrameworkCore;
using NultienShop.DataAccess;
using NultienShop.DataAccess.Domain;
using NultienShop.DataAccess.Domain.ModelConfiguration;
using System.Threading.Tasks;
using NultienShop.DataAccess.Domain.Models;
using Xunit;
using Xunit.Sdk;

namespace NultienShopTEST.Repositories
{
    public class ArticleRepositoryTests
    {
        public readonly DbContextOptions<AppDBContext> _dbContextOptions;
        public AppDBContext _dbContextMock;

        public ArticleRepositoryTests()
        {
            this._dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "NultienTestDB")
                .Options;
            _dbContextMock = new AppDBContext(_dbContextOptions);
            _dbContextMock.Article.AddRange(InitialData.ArticleData);
            _dbContextMock.Inventory.AddRange(InitialData.InventoryData);
            _dbContextMock.InventoryArticle.AddRange(InitialData.InventoryArticleData);
            _dbContextMock.SaveChanges();
        }


        private ArticleRepository CreateArticleRepository()
        {
            return new ArticleRepository(_dbContextMock);
        }

        [Fact]
        public async Task IsArticleValidAndInAnyInventory_ShouldReturnArticle()
        {
            // Arrange
            var articleRepository = CreateArticleRepository();
            int articleId = 1;
            int maxPrice = 1100;
            // Act
            var result = await articleRepository.IsArticleValidAndInAnyInventory(
                articleId,
                maxPrice);

            // Assert
            Assert.NotNull(result);
        }
    }
}