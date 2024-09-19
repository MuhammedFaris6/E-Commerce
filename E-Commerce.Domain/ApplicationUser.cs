using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public Customer? Customer { get; set; }
    }
}
