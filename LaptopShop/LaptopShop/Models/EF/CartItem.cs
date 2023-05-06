using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.EF
{
	public class CartItem
	{
        [Key]
        public int CartItemId { get; set; }
        public int Quantity { get; set; } // số lượng sản phẩm trong giỏ hàng
        public decimal Price { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart? Cart { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
