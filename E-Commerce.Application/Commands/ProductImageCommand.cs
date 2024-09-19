using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class ProductImageCommand : IRequest<ProductImageDTO>
    {
        public Operation Operation { get; }
        public ProductImageDTO ProductImage { get; set; }
        public ProductImageDTO2 ProductImage2 { get; set; }

        public ProductImageCommand(Operation operation, ProductImageDTO productImage)
        {
            Operation = operation;
            ProductImage = productImage;
        }
        public ProductImageCommand(Operation operation, ProductImageDTO productImage, ProductImageDTO2 productImage2)
        {
            Operation = operation;
            ProductImage = productImage;
            ProductImage2 = productImage2;
        }


    }
}
