using E_Commerce.Domain.Entities;

namespace E_Commerce.Domain.Interface
{
    public interface IRepository
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<int> UpdateCategoryteAsync(int Id, Category category);
        Task<int> DeleteCategoryByIdAsync(int id);

        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<int> UpdateCustomerAsync(int Id, Customer customer);
        Task<int> DeleteCustomerByIdAsync(int id);

        Task<Order> CreateOrderAsync(Order order);
        Task<int> UpdateOrderAsync(int Id, Order order);
        Task<int> DeleteOrderByIdAsync(int id);

        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task<int> UpdateOrderItemAsync(int Id, OrderItem orderItem);
        Task<int> DeleteOrderItemByIdAsync(int id);

        Task<Product> CreateProductAsync(Product product);
        Task<int> UpdateProductAsync(int Id, Product product);
        Task<int> DeleteProductByIdAsync(int id);

        Task<ProductImage> CreateProductImageAsync(ProductImage productImage);
        Task<int> UpdateProductImageAsync(int Id, ProductImage productImage);
        Task<int> DeleteProductImageByIdAsync(int id);



        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}
