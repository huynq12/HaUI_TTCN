using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaptopShop.Data;
using LaptopShop.Models.EF;
using X.PagedList;
using X.PagedList.Mvc.Core;
using Microsoft.Data.SqlClient;

namespace LaptopShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly LaptopDbContext _context;

        public ProductController(LaptopDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Product
        public async Task<IActionResult> Index(string sortOrder, int? page)
        {
            // determine sort order
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortByPrice = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            ViewBag.SortByRAM = (sortOrder == "ram") ? "ram_desc" : "ram";

            // get products
            var products = _context.Products.Include(p => p.Category).ToList();

            //// get products based on current filter
            //if (searchString != null) { page = 1; }
            //else { searchString = currentFilter; }
            //ViewBag.CurrentFilter = searchString;

            //// filter products by name
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(p => p.Name.Contains(searchString)).ToList();
            //}

            //// filter products by brand
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(p => p.Brand.Contains(searchString)).ToList();
            //}

            // sort products based on the sort order
            switch (sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case "ram":
                    products = products.OrderBy(p => p.RAM).ToList();
                    break;
                case "ram_desc":
                    products = products.OrderByDescending(p => p.RAM).ToList();
                    break;
                default:
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
            }

            return View(await products.ToPagedListAsync(page ?? 1, 5));
        }

        // GET: Admin/Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
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

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
