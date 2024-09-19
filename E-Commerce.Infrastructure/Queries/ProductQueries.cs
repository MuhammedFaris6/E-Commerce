using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly IMapper mapper;
        private readonly ECommerceDbcontext dbcontext;

        public ProductQueries(IMapper mapper, ECommerceDbcontext dbcontext)
        {
            this.mapper = mapper;
            this.dbcontext = dbcontext;
        }

        public IList<ProductDTO> GetAllProducts()
        {
            var products = from product in dbcontext.products
                           join image in dbcontext.productImages
                           on product.ProductId equals image.ProductId into productImagesGroup
                           select new ProductDTO
                           {
                               ProductId = product.ProductId,
                               ProductName = product.ProductName,
                               CategoryId = product.CategoryId,
                               Price = product.Price,
                               Image = productImagesGroup.Select(x => new ProductImageDTO3
                               {

                                   ImageName = x.ImageName,
                                   Image = x.Image,

                               }).ToList()
                           };
            return mapper.Map<IList<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(int Id)
        {
            return mapper.Map<ProductDTO>(dbcontext.products.FirstOrDefault(x => x.ProductId == Id));
        }
    }
}
