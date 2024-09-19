namespace E_Commerce.Domain.DTO
{
    public class OrderDTO
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? OrderDate { get; set; }
        public int TotalAmount { get; set; }
    }
}
