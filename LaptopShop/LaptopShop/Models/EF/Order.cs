using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
	[Table("Order")]
	public class Order
	{
        [Key]
        [Display(Name = "Id")]
        public int OrderId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? ShipDate { get; set; }

        public bool? IsCancled { get; set; }

        public bool? Paid { get; set; }

        public string? Note { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
