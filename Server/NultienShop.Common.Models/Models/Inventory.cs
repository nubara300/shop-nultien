namespace NultienShop.DataAccess.Domain.Models
{
    public class Inventory : BaseEntity
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string InventoryLocation { get; set; }
    }
}