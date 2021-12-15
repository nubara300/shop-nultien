using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NultienShop.Common.ViewModels;
using NultienShop.IBusinessLogic;
using System.Threading.Tasks;

namespace NultienShopREST.Controllers
{
    public class InventoryController : BaseController
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService) : base(logger)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventory(int page, int pageSize)
        {
            return await TryReturnOk(() => _inventoryService.GetInventories(page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventory([FromBody] InventoryVM inventory)
        {
            return await TryReturnOk(() => _inventoryService.UpdateInventory(inventory));
        }
    }
}