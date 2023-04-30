using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
	[Table("Category")]
	public class Category
	{
        public Category()
        {
			this.Products = new HashSet<Product>();
        }

        [Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(100)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(150)")]
		public string? Description { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
