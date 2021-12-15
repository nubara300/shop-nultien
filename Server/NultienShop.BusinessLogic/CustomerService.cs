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
        private IInventoryRepository _inventoryRepository;

        public CustomerService(ILogger<CustomerService> logger, IBaseRepository baseRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
        }

        public async Task<List<CustomerVM>> GetCustomers(int page, int size)
        {
            return (await _baseRepository.GetListByFilter<Customer>(x => x.IsDeleted != true)).AdaptToViewModel();
        }

        public async Task<ValidationResponse> UpdateCustomer(CustomerVM customerVM)
        {
            _baseRepository.AddOrUpdateContext(customerVM.AdaptToModel());
            await _baseRepository.SaveContextAsync();
            return new() { IsSuccess = true, Message = "Customer added" };
        }
    }
}