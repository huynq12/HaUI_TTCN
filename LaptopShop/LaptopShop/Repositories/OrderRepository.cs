using LaptopShop.Data;
using LaptopShop.Interfaces;
using LaptopShop.Models.EF;
using System;

namespace LaptopShop.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly LaptopDbContext _context;
		private readonly Cart _cart;


		public OrderRepository(LaptopDbContext LaptopDbContext, Cart shoppingCart)
		{
			_context = LaptopDbContext;
			_cart = shoppingCart;
		}


		public void CreateOrder(Order order)
		{
			order.OrderDate = DateTime.Now;

			_context.Orders.Add(order);

			var shoppingCartItems = _cart.CartItems;

			foreach (var item in shoppingCartItems)
			{
				var orderDetail = new OrderDetail()
				{
					Quantity = item.Amount,
					ProductId = item.Product.Id,
					OrderId = order.Id,
					Price = item.Product.Price
				};

				_context.OrderDetails.Add(orderDetail);
			}

			_context.SaveChanges();
		}
	}
}
