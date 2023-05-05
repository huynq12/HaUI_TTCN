using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
	[Table("OrderDetail")]
	public class OrderDetail
	{
        [Key]
        [Display(Name = "Id")]
        public int OrderDetailId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        [Required]
        public decimal? Total
        {
            get
            {
                return Quantity * Price - Discount;
            }
        }

        public string? Status { get; set; }

        public DateTime? ReceivedDate { get; set; }

        [ForeignKey("PorductId")]
        public virtual Product? Product { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
    }

}
