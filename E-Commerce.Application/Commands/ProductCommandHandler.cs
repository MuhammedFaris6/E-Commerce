using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class ProductCommandHandler : IRequestHandler<ProductCommand, ProductDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ProductCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductDTO> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            Product productEntity;
            switch (request.Operation)
            {
                case Operation.Create:
                    productEntity = new Product
                    {
                        ProductId = request.Product.ProductId,
                        ProductName = request.Product2.ProductName,
                        CategoryId = request.Product2.CategoryId,
                        Price = request.Product2.Price
                    };
                    var createdProduct = await repository.CreateProductAsync(productEntity);
                    return mapper.Map<ProductDTO>(createdProduct);
                case Operation.Update:
                    var UpdatedEntity = new Product
                    {
                        ProductId = request.Product.ProductId,
                        ProductName = request.Product2.ProductName,
                        CategoryId = request.Product2.CategoryId,
                        Price = request.Product2.Price
                    };
                    await repository.UpdateProductAsync(request.Product.ProductId, UpdatedEntity);
                    return mapper.Map<ProductDTO>(UpdatedEntity);
                case Operation.Delete:
                    await repository.DeleteProductByIdAsync(request.Product.ProductId);
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
