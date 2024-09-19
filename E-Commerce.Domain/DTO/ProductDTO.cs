namespace E_Commerce.Domain.DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }

        public int Price { get; set; }

        public IList<ProductImageDTO3>? Image { get; set; }
    }
}
