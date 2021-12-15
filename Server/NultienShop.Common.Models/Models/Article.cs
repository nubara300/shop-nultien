namespace NultienShop.DataAccess.Domain.Models
{
    public class Article : BaseEntity
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int ArticlePrice { get; set; }
    }
}