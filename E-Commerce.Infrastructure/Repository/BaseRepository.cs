using AutoMapper;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Interface;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository
{
    public class BaseRepository : IRepository
    {
        private readonly ECommerceDbcontext dbcontext;
        private readonly IMapper mapper;

        public BaseRepository(ECommerceDbcontext dbcontext, IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await dbcontext.AddAsync(category);
            await dbcontext.SaveChangesAsync();
            return category;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await dbcontext.AddAsync(customer);
            await dbcontext.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await dbcontext.AddAsync(order);
            await dbcontext.SaveChangesAsync();
            return order;
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            await dbcontext.AddAsync(orderItem);
            await dbcontext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await dbcontext.AddAsync(product);
            await dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteCategoryByIdAsync(int id)
        {
            return await dbcontext.categories.Where(x => x.CategoryId == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteCustomerByIdAsync(int id)
        {
            return await dbcontext.customers.Where(x => x.CustomerId == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteOrderByIdAsync(int id)
        {
            return await dbcontext.orders.Where(x => x.OrderId == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteOrderItemByIdAsync(int id)
        {
            return await dbcontext.orderItems.Where(x => x.OrderItemId == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteProductByIdAsync(int id)
        {
            return await dbcontext.products.Where(x => x.ProductId == id).ExecuteDeleteAsync();
        }

        public async Task<int> UpdateCategoryteAsync(int Id, Category category)
        {
            return await dbcontext.categories.Where(x => x.CategoryId == Id)
                                     .ExecuteUpdateAsync(setters => setters

                                                        .SetProperty(m => m.CategoryName, category.CategoryName)
                                                        );
        }
        public async Task<int> UpdateCustomerAsync(int Id, Customer customer)
        {
            return await dbcontext.customers.Where(x => x.CustomerId == Id)
                                     .ExecuteUpdateAsync(setters => setters

                                                        .SetProperty(m => m.CustomerName, customer.CustomerName)
                                                        .SetProperty(m => m.Email, customer.Email)
                                                        .SetProperty(m => m.ProfilePhoto, customer.ProfilePhoto)
                                                        );
        }

        public async Task<int> UpdateOrderAsync(int Id, Order order)
        {
            return await dbcontext.orders.Where(x => x.OrderId == Id)
                                     .ExecuteUpdateAsync(setters => setters

                                                        .SetProperty(m => m.CustomerId, order.CustomerId)
                                                        .SetProperty(m => m.OrderDate, order.OrderDate)
                                                        .SetProperty(m => m.TotalAmount, order.TotalAmount)
                                                        );
        }

        public async Task<int> UpdateOrderItemAsync(int Id, OrderItem orderItem)
        {
            return await dbcontext.orderItems.Where(x => x.OrderItemId == Id)
                                     .ExecuteUpdateAsync(setters => setters

                                                        .SetProperty(m => m.OrderId, orderItem.OrderId)
                                                        .SetProperty(m => m.ProductId, orderItem.ProductId)
                                                        .SetProperty(m => m.Quantity, orderItem.Quantity)
                                                        .SetProperty(m => m.UnitPrice, orderItem.UnitPrice)
                                                        );
        }

        public async Task<int> UpdateProductAsync(int Id, Product product)
        {
            return await dbcontext.products.Where(x => x.ProductId == Id)
                                     .ExecuteUpdateAsync(setters => setters

                                                        .SetProperty(m => m.ProductName, product.ProductName)
                                                        .SetProperty(m => m.CategoryId, product.CategoryId)
                                                        .SetProperty(m => m.Price, product.Price)
                                                        );
        }

        public async Task<ProductImage> CreateProductImageAsync(ProductImage productImage)
        {
            await dbcontext.AddAsync(productImage);
            await dbcontext.SaveChangesAsync();
            return productImage;
        }

        public async Task<int> UpdateProductImageAsync(int Id, ProductImage productImage)
        {
            return await dbcontext.productImages.Where(x => x.ImageId == Id)
                                     .ExecuteUpdateAsync(setters => setters

                                                        .SetProperty(m => m.ImageName, productImage.ImageName)
                                                        .SetProperty(m => m.Image, productImage.Image)
                                                        .SetProperty(m => m.ProductId, productImage.ProductId)
                                                        );
        }

        public async Task<int> DeleteProductImageByIdAsync(int id)
        {
            return await dbcontext.productImages.Where(x => x.ImageId == id).ExecuteDeleteAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await dbcontext.products.FindAsync(productId);
            return mapper.Map<Product>(product);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await dbcontext.orderItems.Where(oi => oi.OrderId == orderId).ToListAsync();
        }
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await dbcontext.customers.FindAsync(customerId);
        }


    }
}
