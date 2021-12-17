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

    public class ArticleOrderRequest
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

}