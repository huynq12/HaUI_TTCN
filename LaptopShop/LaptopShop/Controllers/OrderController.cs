using LaptopShop.Data;
using LaptopShop.Interfaces;
using LaptopShop.Models.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
	public class OrderController : Controller
	{
        private readonly LaptopDbContext _context;

        public OrderController(LaptopDbContext context)
		{
			_context = context;
		}

		//[Authorize]
		public IActionResult Checkout()
		{
			return View();
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
