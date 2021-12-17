using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NultienShop.DataAccess.Domain.Models
{
    public class Inventory : BaseEntity
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string InventoryLocation { get; set; }

        [NotMapped]
        public ICollection<InventoryArticle> InventoryArticles { get; set; } = new Collection<InventoryArticle>();
    }
}