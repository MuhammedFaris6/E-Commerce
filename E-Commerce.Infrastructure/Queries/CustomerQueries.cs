using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly ECommerceDbcontext dbcontext;
        private readonly IMapper mapper;

        public CustomerQueries(ECommerceDbcontext dbcontext, IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }
        public IList<CustomerDTO> GetAllCustomers()
        {
            return mapper.Map<IList<CustomerDTO>>(dbcontext.customers.ToList());
        }

        public CustomerDTO GetCustomerById(int Id)
        {
            return mapper.Map<CustomerDTO>(dbcontext.customers.FirstOrDefault(x => x.CustomerId == Id));
        }
    }
}
