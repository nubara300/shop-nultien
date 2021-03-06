using NultienShop.Common.ViewModels;
using System.Threading.Tasks;

namespace NultienShop.IBusinessLogic
{
    public interface ICustomerService
    {
        Task<PaginationResponse<CustomerVM>> GetCustomers(int page, int size);

        Task<ValidationResponse> UpdateCustomer(CustomerVM customer);
    }
}