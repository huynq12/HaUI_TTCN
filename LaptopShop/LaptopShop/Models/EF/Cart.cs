using LaptopShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.EF
{
	public class Cart
	{
        [Key]
        public int CartId { get; set; }
        public decimal Total { get; set; }
        
        public virtual ICollection<CartItem> CartItems { get; set; }

        public Cart()
        {
            this.CartItems = new HashSet<CartItem>();
        }
    }
}
