using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
	[Table("OrderDetail")]
	public class OrderDetail
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "decimal(15)")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(100)")]
		public string Status { get; set; } // đang giao hàng | giao hàng thành công

        [DataType(DataType.Date)]
        public DateTime? ReceivedDate { get; set; } // ngày nhận hàng

		[Column(TypeName = "ntext")]
		public string? Note { get; set; }

		public int? ProductId { get; set; }
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }

		public int? OrderId { get; set; }
		[ForeignKey("OrderId")]
		public virtual Order Order { get; set; }
	}
}
