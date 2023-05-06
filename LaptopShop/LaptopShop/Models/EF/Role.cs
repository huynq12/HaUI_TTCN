using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public string? Description { get; set; }
    }
}
