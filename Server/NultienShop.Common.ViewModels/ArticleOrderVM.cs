using System;
using System.ComponentModel.DataAnnotations;

namespace NultienShop.Common.ViewModels
{
    public class ArticleVM
    {
        public int? ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int ArticlePrice { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ArticleOrderVM
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MaxPrice { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }

    public class CustomerVM
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }

    public class OrdersVM
    {
        public int ArticleId { get; set; }
        public int TotalPrice { get; set; }
        public bool? Successfull { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class InventoryVM
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string InventoryLocation { get; set; }
        public string ArticleName { get; set; }
        public int ArticlePrice { get; set; }
        public int ArticlQuantity { get; set; }
        public int ArticleId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}