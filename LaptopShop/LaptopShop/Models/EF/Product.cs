using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models.EF
{
	[Table("Product")]
	public class Product
	{
        [Key]
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Operating System")]
        public string OperatingSystem { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Monitor { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string CPU { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string RAM { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Storage { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Graphics { get; set; }

        public double Weight { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Color { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Battery Infor")]
        public string BatteryInfor { get; set; }

        public byte Warranty { get; set; } // số tháng bảo hành

        public string? Description { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public decimal Price { get; set; }

        [Display(Name = "Promotional Price")]
        public decimal? PromotionalPrice { get; set; } // giá khuyến mãi

        [Required(ErrorMessage = "This field is required!")]
        public int Quantity { get; set; } // số lượng còn trong kho

        [Display(Name = "Available")]

        public bool? IsAvailable
        {
            get
            {
                if (Quantity > 0) return true;
                return false;
            }
        }

        [Display(Name = "Category Name")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
