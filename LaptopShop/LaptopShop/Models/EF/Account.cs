using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LaptopShop.Models.EF
{
    public class Account
    {
        [Key]
        [Display(Name = "CategoryId")]
        public int AccountCategoryId { get; set; }

        public string? Avatar { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Phone { get; set; }

        public string? Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        public bool? Active { get; set; }

        [Required]
        public int? RoleCategoryId { get; set; }

        [ForeignKey("RoleCategoryId")]
        public virtual Role? Role { get; set; }

        public string? CartCategoryId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Account()
        {
            Orders = new HashSet<Order>();
        }
    }
}
