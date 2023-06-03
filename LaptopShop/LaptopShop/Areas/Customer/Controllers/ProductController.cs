using LaptopShop.Data;
using LaptopShop.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly LaptopDbContext _context;

        public ProductController(LaptopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var listProduct = await _context.Products.ToListAsync();
            return View(listProduct);
        }
    }
}
