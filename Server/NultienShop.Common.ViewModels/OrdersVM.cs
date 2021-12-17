using System;

namespace NultienShop.Common.ViewModels
{
    public class OrdersVM
    {
        public int ArticleId { get; set; }
        public int TotalPrice { get; set; }
        public bool? Successfull { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class OrderMetrics
    {
        public int SuccsefullOrders { get; set; }
        public int UnsucsefullOrders { get; set; }
    }

    public class OrderMetricsRequest
    {
        public int? CustomerId { get; set; }
        public int? ArticleId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }


}