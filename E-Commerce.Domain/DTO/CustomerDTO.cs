namespace E_Commerce.Domain.DTO
{
    public class CustomerDTO
    {

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string? ApplicationUserId { get; set; }

    }
}
