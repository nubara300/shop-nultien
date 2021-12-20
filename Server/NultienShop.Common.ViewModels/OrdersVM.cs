using System;

namespace NultienShop.Common.ViewModels
{
    public class OrderMetrics
    {
        public OrderMetrics()
        {
        }

        public OrderMetrics(int successfulOrders, int unsuccessfulOrders)
        {
            SuccessfulOrders = successfulOrders;
            UnsuccessfulOrders = unsuccessfulOrders;
        }

        public int SuccessfulOrders { get; set; }
        public int UnsuccessfulOrders { get; set; }
    }

    public class OrderMetricsRequest
    {
        public int? CustomerId { get; set; }
        public int? ArticleId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}