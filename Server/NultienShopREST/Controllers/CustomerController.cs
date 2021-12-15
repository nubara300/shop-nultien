using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using System.Threading.Tasks;

namespace NultienShopREST.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService) : base(logger)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(int page = 0, int size = 10)
        {
            return await TryReturnOk(() => _customerService.GetCustomers(page, size));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerVM customer)
        {
            return await TryReturnOk(() => _customerService.UpdateCustomer(customer));
        }
    }
}