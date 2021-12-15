using System;
using System.Collections.Generic;

namespace NultienShop.DataAccess.Domain.Models
{
    public class Order : BaseEntity
    {
        public Order(int quantity, int customerId, int articleId, int articlePrice)
        {
            Quantity = quantity;
            CustomerId = customerId;
            DateCreated = DateTime.UtcNow;
            ArticleOrders.Add(new() { ArticleId = articleId });
            TotalCost = articlePrice * quantity;
        }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ArticleOrder> ArticleOrders { get; set; }
    }
}