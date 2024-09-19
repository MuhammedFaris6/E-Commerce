using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class ProductImageCommandHandler : IRequestHandler<ProductImageCommand, ProductImageDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ProductImageCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ProductImageDTO> Handle(ProductImageCommand request, CancellationToken cancellationToken)
        {

            ProductImage productImageEntity;
            switch (request.Operation)
            {
                case Operation.Create:
                    productImageEntity = new ProductImage
                    {
                        ImageName = request.ProductImage2.ImageName,
                        ProductId = request.ProductImage2.ProductId,
                        Image = request.ProductImage.Image
                    };
                    var createdProduct = await repository.CreateProductImageAsync(productImageEntity);
                    return mapper.Map<ProductImageDTO>(createdProduct);
                case Operation.Update:
                    var UpdatedEntity = new ProductImage
                    {
                        ImageId = request.ProductImage.ImageId,
                        ImageName = request.ProductImage2.ImageName,
                        ProductId = request.ProductImage2.ProductId,
                        Image = request.ProductImage.Image
                    };
                    await repository.UpdateProductImageAsync(request.ProductImage.ImageId, UpdatedEntity);
                    return mapper.Map<ProductImageDTO>(UpdatedEntity);
                case Operation.Delete:
                    await repository.DeleteProductImageByIdAsync(request.ProductImage.ImageId);
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

