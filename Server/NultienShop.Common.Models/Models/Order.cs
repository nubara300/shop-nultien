using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NultienShop.DataAccess.Domain.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(int quantity, int customerId, bool completed, int articleId, int? articlePrice)
        {
            Quantity = quantity;
            CustomerId = customerId;
            DateCreated = DateTime.UtcNow;
            Completed = completed;
            TotalCost = articlePrice.HasValue ? articlePrice * quantity : 0;
            ArticleOrders.Add(new() { ArticleId = articleId });
        }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int? TotalCost { get; set; }
        public bool? Completed { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ArticleOrder> ArticleOrders { get; set; } = new Collection<ArticleOrder>();
    }
}