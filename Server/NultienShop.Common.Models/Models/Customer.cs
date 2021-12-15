using System.Collections.Generic;

namespace NultienShop.DataAccess.Domain.Models
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}