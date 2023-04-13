namespace LaptopShop.Models.EF
{
	public class CartItem
	{
		public int ItemId { get; set; }
		public Laptop Laptop { get; set; }
		public int Amount { get; set; }
		public string CartId { get; set; }
	}
}
