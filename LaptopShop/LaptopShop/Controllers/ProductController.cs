using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaptopShop.Data;
using LaptopShop.Models.EF;
using LaptopShop.ViewModels;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace LaptopShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly LaptopDbContext _context;

        public ProductController(LaptopDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var laptopDbContext = _context.Products.Include(p => p.Category);
            return View(await laptopDbContext.ToListAsync());
        }

        // GET: Product/AddOrEdit/1
        public async Task<IActionResult> AddOrEdit(int? id = 0)
        {
            if (id == 0)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
                return View();
            }
            else
            {
                if (id == null || _context.Products == null)
                {
                    return NotFound();
                }

                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
                return View(product);
            }
        }

        // POST: Product/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(ProductViewModel viewModel)
        {
            if (viewModel.Id == 0) // Add
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

                var product = new Product()
                {
                    Brand = viewModel.Brand,
                    Name = viewModel.Name,
                    OperatingSystem = viewModel.OperatingSystem,
                    Monitor = viewModel.Monitor,
                    CPU = viewModel.CPU,
                    RAM = viewModel.RAM,
                    Storage = viewModel.Storage,
                    Graphics = viewModel.Graphics,
                    Weight = viewModel.Weight,
                    Color = viewModel.Color,
                    BatteryInfor = viewModel.BatteryInfor,
                    Warranty = viewModel.Warranty,
                    Description = viewModel.Description,
                    ImageUrl = viewModel.ImageUrl,
                    Price = viewModel.Price,
                    PromotionalPrice = viewModel.PromotionalPrice,
                    Quantity = viewModel.Quantity,
                    CategoryId = viewModel.CategoryId
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "Product");
            }
            else // Edit
            {
                var product = await _context.Products.FindAsync(viewModel.Id);

                if (product != null)
                {
                    product.Brand = viewModel.Brand;
                    product.Name = viewModel.Name;
                    product.OperatingSystem = viewModel.OperatingSystem;
                    product.Monitor = viewModel.Monitor;
                    product.CPU = viewModel.CPU;
                    product.RAM = viewModel.RAM;
                    product.Storage = viewModel.Storage;
                    product.Graphics = viewModel.Graphics;
                    product.Weight = viewModel.Weight;
                    product.Color = viewModel.Color;
                    product.BatteryInfor = viewModel.BatteryInfor;
                    product.Warranty = viewModel.Warranty;
                    product.Description = viewModel.Description;
                    product.ImageUrl = viewModel.ImageUrl;
                    product.Price = viewModel.Price;
                    product.PromotionalPrice = viewModel.PromotionalPrice;
                    product.Quantity = viewModel.Quantity;
                    product.CategoryId = viewModel.CategoryId;

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), "Product");
                }

                return View(product);
            }            
        }

        // GET: Product/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'LaptopDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
