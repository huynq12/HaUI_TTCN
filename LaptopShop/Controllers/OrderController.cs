using LaptopShop.Interfaces;
using LaptopShop.Models.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly Cart _cart;

		public OrderController(IOrderRepository orderRepository, Cart cart)
		{
			_orderRepository = orderRepository;
			_cart = cart;
		}

		//[Authorize]
		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		//[Authorize]
		public IActionResult Checkout(Order order)
		{
			var items = _cart.GetCartItems();
			_cart.CartItems = items;
			if (_cart.CartItems.Count == 0)
			{
				ModelState.AddModelError("", "Your card is empty, add some product first");
			}

			if (ModelState.IsValid)
			{
				_orderRepository.CreateOrder(order);
				_cart.ClearCart();
				return RedirectToAction("CheckoutComplete");
			}

			return View(order);
		}

		public IActionResult CheckoutComplete()
		{
			ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
			return View();
		}
	}
}
