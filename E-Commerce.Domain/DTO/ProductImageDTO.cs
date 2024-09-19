namespace E_Commerce.Domain.DTO
{
    public class ProductImageDTO
    {
        public int ImageId { get; set; }
        public string? ImageName { get; set; }
        public byte[]? Image { get; set; }
        public int ProductId { get; set; }

    }
}
