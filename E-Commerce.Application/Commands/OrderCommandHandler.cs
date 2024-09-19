using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, OrderDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public OrderCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<OrderDTO> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            Order orderEntity;



            switch (request.Operation)
            {
                case Operation.Create:
                    orderEntity = new Order
                    {
                        OrderId = request.Order.OrderId,
                        CustomerId = request.Order2.CustomerId,
                        OrderDate = request.Order2.OrderDate,
                        TotalAmount = request.Order.TotalAmount
                    };
                    var createdOrder = await repository.CreateOrderAsync(orderEntity);
                    return mapper.Map<OrderDTO>(createdOrder);

                case Operation.Update:
                    orderEntity = new Order
                    {
                        OrderId = request.Order.OrderId,
                        CustomerId = request.Order2.CustomerId,
                        OrderDate = request.Order2.OrderDate,
                        TotalAmount = request.Order.TotalAmount
                    };
                    var updatedOrder = await repository.UpdateOrderAsync(orderEntity.OrderId, orderEntity);
                    return mapper.Map<OrderDTO>(updatedOrder);

                case Operation.Delete:
                    await repository.DeleteOrderByIdAsync(request.Order.OrderId);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
