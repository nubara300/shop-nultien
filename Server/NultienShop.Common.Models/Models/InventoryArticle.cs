namespace NultienShop.DataAccess.Domain.Models
{
    public class InventoryArticle
    {
        public int InventoryArticleId { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int ArticleQuantity { get; set; }
    }
}