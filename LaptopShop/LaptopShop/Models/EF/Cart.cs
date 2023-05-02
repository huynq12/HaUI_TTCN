using LaptopShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.EF
{
	[Table("Cart")]
	public class Cart
	{
		public int CartId { get; set; }
		public decimal Total { get; set; }
	}
}
