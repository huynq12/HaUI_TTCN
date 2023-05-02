using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
