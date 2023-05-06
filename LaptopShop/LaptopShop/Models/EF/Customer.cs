using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.EF
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }
        [ForeignKey("CartId")]
        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}
