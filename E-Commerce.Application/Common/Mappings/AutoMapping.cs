using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Common.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO2>().ReverseMap();
            CreateMap<CategoryDTO, CategoryDTO2>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderItem, ProductDTO>().ReverseMap();
            CreateMap<ProductImage, ProductImageDTO>().ReverseMap();

        }
    }
}
