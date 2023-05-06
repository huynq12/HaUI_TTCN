using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.EF
{
	public class Order
	{
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Note { get; set; }
        public bool? IsCancled { get; set; } // còn đơn || đã huỷ đơn
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
