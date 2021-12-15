using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NultienShop.BusinessLogic.Mappers
{
    public static class Mappers
    {
        public static List<CustomerVM> AdaptToViewModel(this List<Customer> customerVM)
        {
            return customerVM == null ? new List<CustomerVM>() : customerVM.Select(x => new CustomerVM
            {
                CustomerEmail = x.CustomerEmail,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName
            }).ToList();
        }

        public static Customer AdaptToModel(this CustomerVM customerVM)
        {
            return customerVM == null ? new() : new()
            {
                CustomerId = SetId(customerVM.CustomerId),
                CustomerEmail = customerVM.CustomerEmail,
                CustomerName = customerVM.CustomerName,
            };
        }

        public static int SetId(int? id)
        {
            return (int)(id != null && id > 0 ? id : 0);
        }
    }
}