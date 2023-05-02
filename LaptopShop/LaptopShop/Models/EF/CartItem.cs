using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.EF
{
	[Table("CartItem")]
	public class CartItem
	{
		[Key]
		public int ItemId { get; set; }
		public Product Product { get; set; }
		public int Amount { get; set; }
		public int CartId { get; set; }
	}
}
