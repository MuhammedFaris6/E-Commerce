using E_Commerce.Domain;
using E_Commerce.Domain.Interface;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Queries;
using E_Commerce.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbcontext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("E-Commerce") ??
                    throw new Exception("connection string 'E-Commerce not found' "))
            );
            services.AddTransient<IRepository, BaseRepository>();
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<ICustomerQueries, CustomerQueries>();
            services.AddScoped<IOrderQueries, OrderQueries>();
            services.AddScoped<IOrderItemQueries, OrderItemQueries>();
            services.AddScoped<IProductQueries, ProductQueries>();
            services.AddScoped<IDepartmentQueries, DepartmentQueries>();


            //identity services
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ECommerceDbcontext>()
                .AddDefaultTokenProviders();

            //authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
            return services;
        }
    }
}
