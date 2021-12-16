namespace NultienShop.DataAccess.Domain.Models
{
    public class ArticleOrder
    {
        public int ArticleId { get; set; }
        public int ArticleOrderId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Article Article { get; set; }
    }
}