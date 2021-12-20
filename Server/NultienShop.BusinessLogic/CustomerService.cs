using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using NultienShop.IBusinessLogic;
using NultienShop.IDataAccess;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;

namespace NultienShop.BusinessLogic
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IBaseRepository _baseRepository;

        public CustomerService(ILogger<CustomerService> logger, IBaseRepository baseRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
        }

        public async Task<PaginationResponse<CustomerVM>> GetCustomers(int page, int size)
        {
            var list = (await _baseRepository.GetListByFilter<Customer>(x => x.IsDeleted != true, new(page, size)));
            var total = await _baseRepository.Count<Customer>(x => true);
            return new(list.Adapt<List<CustomerVM>>(), total);
        }

        public async Task<ValidationResponse> UpdateCustomer(CustomerVM customerVM)
        {
            _logger.LogInformation("Customer added/updated");
            _baseRepository.AddOrUpdateContext(customerVM.Adapt<Customer>());
            await _baseRepository.SaveContextAsync();
            return new() { IsSuccess = true, Message = "Customer updated" };
        }
    }
}