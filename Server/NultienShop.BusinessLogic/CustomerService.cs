using Microsoft.Extensions.Logging;
using NultienShop.BusinessLogic.Mappers;
using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NultienShop.BusinessLogic
{
    public class CustomerService : ICustomerService
    {
        private ILogger<CustomerService> _logger;
        private IBaseRepository _baseRepository;

        public CustomerService(ILogger<CustomerService> logger, IBaseRepository baseRepository, IInventoryRepository inventoryRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
        }

        public async Task<PaginationResponse<CustomerVM>> GetCustomers(int page, int size)
        {
            var list = (await _baseRepository.GetListByFilter<Customer>(x => x.IsDeleted != true)).AdaptToViewModel();
            int total = await _baseRepository.Count<Customer>(x=>true);
            return new(list, total);
        }

        public async Task<ValidationResponse> UpdateCustomer(CustomerVM customerVM)
        {
            _baseRepository.AddOrUpdateContext(customerVM.AdaptToModel());
            await _baseRepository.SaveContextAsync();
            return new() { IsSuccess = true, Message = "Customer updated" };
        }
    }
}