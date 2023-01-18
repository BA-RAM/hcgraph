using System.ComponentModel.DataAnnotations;

namespace hcgraph.Domain.Models
{
    public class Order : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
