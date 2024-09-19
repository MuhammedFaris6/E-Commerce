using E_Commerce.Domain.DTO;

namespace E_Commerce.Domain.Interface.IQueries
{
    public interface ICustomerQueries
    {
        IList<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int Id);
    }
}
