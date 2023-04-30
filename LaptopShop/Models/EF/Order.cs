using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
	[Table("Order")]
	public class Order
	{
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(50)")]
		public string CustomerName { get; set; } // họ tên người nhận hàng

		[Column(TypeName = "nvarchar(70)")]
		public string CustomerEmail { get; set; } // email người nhận hàng

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(20)")]
		public string CustomerPhone { get; set; } // số điện thoại người nhận hàng

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(250)")]
		public string CustomerAddress { get; set; } // địa chỉ nhận hàng

		[Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } // ngày đặt hàng

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(100)")]
		public string? Status { get; set; } 

		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
