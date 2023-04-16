using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace LaptopShop.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Operating System is required.")]
        [Display(Name = "Operating System")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "Monitor information is required.")]
        [Display(Name = "Monitor")]
        public string Monitor { get; set; }

        [Required(ErrorMessage = "CPU information is required.")]
        [Display(Name = "CPU")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "RAM information is required.")]
        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Storage information is required.")]
        [Display(Name = "Storage")]
        public string Storage { get; set; }

        [Required(ErrorMessage = "Graphics information is required.")]
        [Display(Name = "Graphics")]
        public string Graphics { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Battery information is required.")]
        [Display(Name = "Battery Information")]
        public string BatteryInfor { get; set; }

        [Required(ErrorMessage = "Warranty is required.")]
        [Display(Name = "Warranty")]
        public byte Warranty { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Promotional Price")]
        public decimal? PromotionalPrice { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public SelectList Categories { get; set; }
    }
}
