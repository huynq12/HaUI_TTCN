using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
    public class Role
    {
        [Key]
        [Display(Name = "Id")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string RoleName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Description { get; set; }
    }
}
