using NultienShop.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NultienShop.IBusinessLogic
{
    public interface ICustomerService
    {
        Task<List<CustomerVM>> GetCustomers(int page, int size);

        Task<ValidationResponse> UpdateCustomer(CustomerVM customer);
    }
}