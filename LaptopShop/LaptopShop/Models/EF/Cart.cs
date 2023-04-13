using LaptopShop.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LaptopShop.Models.EF
{
	public class Cart
	{
		private readonly LaptopDbContext _context;
		public Cart(LaptopDbContext context)
		{
			_context = context;
		}

		public string CartId { get; set; }

		public List<CartItem> CartItems { get; set; }

		public static Cart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?
				.HttpContext.Session;

			var context = services.GetService<LaptopDbContext>();
			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", cartId);

			return new Cart(context) { CartId = cartId };
		}

		public void AddToCart(Laptop Laptop, int amount)
		{
			var shoppingCartItem =
					_context.CartItems.SingleOrDefault(
						s => s.Laptop.Id == Laptop.Id && s.CartId == CartId);

			if (shoppingCartItem == null)
			{
				shoppingCartItem = new CartItem
				{
					CartId = CartId,
					Laptop = Laptop,
					Amount = 1
				};

				_context.CartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;
			}
			_context.SaveChanges();
		}

		public int RemoveFromCart(Laptop Laptop)
		{
			var shoppingCartItem =
					_context.CartItems.SingleOrDefault(
						s => s.Laptop.Id == Laptop.Id && s.CartId == CartId);

			var localAmount = 0;

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
					localAmount = shoppingCartItem.Amount;
				}
				else
				{
					_context.CartItems.Remove(shoppingCartItem);
				}
			}

			_context.SaveChanges();

			return localAmount;
		}

		public List<CartItem> GetShoppingCartItems()
		{
			return CartItems ??
				   (CartItems =
					   _context.CartItems.Where(c => c.CartId == CartId)
						   .Include(s => s.Laptop)
						   .ToList());
		}

		public void ClearCart()
		{
			var cartItems = _context
				.CartItems
				.Where(cart => cart.CartId == CartId);

			_context.CartItems.RemoveRange(cartItems);

			_context.SaveChanges();
		}

		public decimal GetShoppingCartTotal()
		{
			var total = _context.CartItems.Where(c => c.CartId == CartId)
				.Select(c => c.Laptop.Price * c.Amount).Sum();
			return total;
		}
	}
}
