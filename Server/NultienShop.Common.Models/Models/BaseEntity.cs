using System;

namespace NultienShop.DataAccess.Domain.Models
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}