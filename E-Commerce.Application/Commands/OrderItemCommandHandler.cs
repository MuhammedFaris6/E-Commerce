using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class OrderItemCommandHandler : IRequestHandler<OrderItemCommand, OrderItemDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public OrderItemCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<OrderItemDTO> Handle(OrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem orderItemEntity;
            var product = await repository.GetProductByIdAsync(request.OrderItem2.ProductId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }
            var unitPrice = product.Price;
            switch (request.Operation)
            {
                case Operation.Create:

                    orderItemEntity = new OrderItem
                    {
                        OrderItemId = request.OrderItem.OrderItemId,
                        OrderId = request.OrderItem2.OrderId,
                        ProductId = request.OrderItem2.ProductId,
                        Quantity = request.OrderItem2.Quantity,
                        UnitPrice = unitPrice
                    };
                    var createdOrderItem = await repository.CreateOrderItemAsync(orderItemEntity);
                    return mapper.Map<OrderItemDTO>(createdOrderItem);

                case Operation.Update:
                    orderItemEntity = new OrderItem
                    {
                        OrderItemId = request.OrderItem.OrderItemId,
                        OrderId = request.OrderItem2.OrderId,
                        ProductId = request.OrderItem2.ProductId,
                        Quantity = request.OrderItem2.Quantity,
                        UnitPrice = request.OrderItem.UnitPrice
                    };
                    var updatedOrderItem = await repository.UpdateOrderItemAsync(orderItemEntity.OrderItemId, orderItemEntity);
                    return mapper.Map<OrderItemDTO>(updatedOrderItem);

                case Operation.Delete:
                    await repository.DeleteOrderItemByIdAsync(request.OrderItem.OrderItemId);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }

}
