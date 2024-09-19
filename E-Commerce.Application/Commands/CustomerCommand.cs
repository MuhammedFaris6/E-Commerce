using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class CustomerCommand : IRequest<CustomerDTO>
    {
        public Operation Operation { get; }
        public CustomerDTO Customer { get; set; }
        public CustomerDTO2 Customer2 { get; set; }

        public CustomerCommand(Operation operation, CustomerDTO customer)
        {
            Operation = operation;
            Customer = customer;
        }
        public CustomerCommand(Operation operation, CustomerDTO customer, CustomerDTO2 customer2)
        {
            Operation = operation;
            Customer = customer;
            Customer2 = customer2;
        }
    }

}

