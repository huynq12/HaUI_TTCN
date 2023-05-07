﻿using LaptopShop.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Data
{
    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
