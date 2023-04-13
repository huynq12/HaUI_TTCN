using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
