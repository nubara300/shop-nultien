using System;

namespace NultienShop.Common.ViewModels
{
    public class InventoryVM
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string InventoryLocation { get; set; }
        public string ArticleName { get; set; }
        public int ArticlePrice { get; set; }
        public int ArticleQuantity { get; set; }
        public int ArticleId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
