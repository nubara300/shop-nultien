using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NultienShop.DataAccess.Domain.Models;

namespace NultienShop.DataAccess.Domain.ModelConfiguration
{
    public class ArticleOrderConfig : IEntityTypeConfiguration<ArticleOrder>
    {
        public void Configure(EntityTypeBuilder<ArticleOrder> entity)
        {
            entity.HasOne(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class InventoryArticleConfig : IEntityTypeConfiguration<InventoryArticle>
    {
        public void Configure(EntityTypeBuilder<InventoryArticle> entity)
        {
            entity.HasOne(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Inventory).WithMany().HasForeignKey(x => x.InventoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}