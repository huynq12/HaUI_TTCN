using LaptopShop.Data;
using LaptopShop.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Controllers
{
    public class CartController : Controller
    {
        private readonly LaptopDbContext _context;

        public CartController(LaptopDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public void AddToCart(Product product,int cartId)
        {
            var  item = _context.CartItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.CartId == cartId);

            if (item == null)
            {
                item = new CartItem
                {
                    CartId = cartId,
                    Product = product,
                    Amount = 1
                };

                _context.CartItems.Add(item);
            }
            else
            {
                item.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(Product  product, int cartId)
        {
            var  item = _context.CartItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.CartId == cartId);


            if ( item != null)
            {              
                _context.CartItems.Remove(item); 
            }

            _context.SaveChanges();
        }
        public void EditProductAmount(int productId, int cartId, int feature)
        {
            var item = _context.CartItems.FirstOrDefault(i => i.Product.Id == productId && i.CartId == cartId);

            if(item != null)
            {
                if(feature == 1)
                {
                    item.Amount++;
                }
                if(feature == 0)
                {
                    item.Amount--;
                }
            }
        }
    }


}
