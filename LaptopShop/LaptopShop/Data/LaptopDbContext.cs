﻿using LaptopShop.Models.EF;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LaptopShop.Data
{
	public class LaptopDbContext : IdentityDbContext
	{
		public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options) { }

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Laptop> Laptops { get; set; }
		public DbSet<Category> LaptopCategories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

	}
}
