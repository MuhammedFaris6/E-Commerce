using E_Commerce.Domain;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    public class ECommerceDbcontext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceDbcontext(DbContextOptions<ECommerceDbcontext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
