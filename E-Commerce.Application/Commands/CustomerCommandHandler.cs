using AutoMapper;
using E_Commerce.Domain;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class CustomerCommandHandler : IRequestHandler<CustomerCommand, CustomerDTO>
    {
        private readonly IMapper mapper;
        private readonly IRepository repository;
        public CustomerCommandHandler(IMapper mapper, IRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<CustomerDTO> Handle(CustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customerentity;
            var user = new ApplicationUser();
            switch (request.Operation)
            {

                case Operation.Create:
                    customerentity = new Customer
                    {
                        CustomerId = request.Customer.CustomerId,
                        CustomerName = request.Customer2.CustomerName,
                        Email = request.Customer2.Email,
                        ProfilePhoto = request.Customer.ProfilePhoto,
                        ApplicationUserId = user.Id
                    };
                    var createdcustomer = await repository.CreateCustomerAsync(customerentity);
                    return mapper.Map<CustomerDTO>(createdcustomer);

                case Operation.Update:
                    var updatedEntity = new Customer
                    {
                        CustomerId = request.Customer.CustomerId,
                        CustomerName = request.Customer2.CustomerName,
                        Email = request.Customer2.Email,
                        ProfilePhoto = request.Customer.ProfilePhoto,
                        ApplicationUserId = user.Id
                    };
                    await repository.UpdateCustomerAsync(request.Customer.CustomerId, updatedEntity);

                    return mapper.Map<CustomerDTO>(updatedEntity);

                case Operation.Delete:
                    await repository.DeleteCustomerByIdAsync(request.Customer.CustomerId);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}


