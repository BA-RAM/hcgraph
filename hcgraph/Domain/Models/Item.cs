using System;
using System.ComponentModel.DataAnnotations;

namespace hcgraph.Domain.Models
{
    public class Item : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string ItemNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        public decimal? Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

