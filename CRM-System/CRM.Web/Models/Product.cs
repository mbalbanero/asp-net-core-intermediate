using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Web.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required] 
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; } = string.Empty;
        public string? ProductCategory { get; set; }
        public string? ProductImageUrl { get; set; }
        [Required]
        public decimal Price { get; set; } = 0.0m;
    }
}
