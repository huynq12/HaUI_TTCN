using LaptopShop.Models.EF;

namespace LaptopShop.Interfaces
{
	public interface IOrderRepository
	{
		public void CreateOrder(Order order);
	}
}
