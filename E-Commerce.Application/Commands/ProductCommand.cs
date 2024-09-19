using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class ProductCommand : IRequest<ProductDTO>
    {
        public Operation Operation { get; set; }
        public ProductDTO Product { get; set; }
        public ProductDTO2 Product2 { get; set; }
        public ProductCommand(Operation operation, ProductDTO product)
        {
            Operation = operation;
            Product = product;
        }
        public ProductCommand(Operation operation, ProductDTO product, ProductDTO2 product2)
        {
            Operation = operation;
            Product = product;
            Product2 = product2;
        }
    }
}
