using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaptopShop.Data;
using LaptopShop.Models.EF;

namespace LaptopShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LaptopDbContext _context;

        public CategoryController(LaptopDbContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
              return _context.Categories != null ? 
                          View(await _context.Categories.ToListAsync()) :
                          Problem("Entity set 'LaptopDbContext.Categories'  is null.");
        }

        // GET: Category/AddOrEdit/1
        public IActionResult AddOrEdit(int? id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                return View( _context.Categories.Find(id));
            }
        }

        // POST: Category/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _context.Add(category);
                }
                else
                {
                    _context.Update(category);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Category");
            }
            return View(category);
        }

        // GET: Category/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'LaptopDbContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
