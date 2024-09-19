using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Entities
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public string? ImageName { get; set; }
        public byte[]? Image { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

    }
}
