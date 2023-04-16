using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models.EF
{
	[Table("Product")]
	public class Product
	{
        public Product()
        {
			this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
		public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(50)")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(150)")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(50)")]
		public string OperatingSystem { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string Monitor { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string CPU { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(200)")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(100)")]
		public string Storage { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string Graphics { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public double Weight { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(100)")]
		public string Color { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string BatteryInfor { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public byte Warranty { get; set; } // số tháng bảo hành

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Column(TypeName = "ntext")]
        public string? ImageUrl { get; set; } // link hình ảnh

        [Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "decimal(10)")]
		public decimal Price { get; set; } // giá bán

		[Column(TypeName = "decimal(10)")]
		public decimal? PromotionalPrice { get; set; } // giá khuyến mãi

		[Required(ErrorMessage = "This field is required!")]
		public int Quantity { get; set; } // số lượng còn trong kho

		public int? CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
