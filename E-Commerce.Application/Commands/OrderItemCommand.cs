using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class OrderItemCommand : IRequest<OrderItemDTO>
    {
        public Operation Operation { get; }
        public OrderItemDTO OrderItem { get; set; }
        public OrderItemDTO2 OrderItem2 { get; set; }

        public OrderItemCommand(Operation operation, OrderItemDTO orderItem)
        {
            Operation = operation;
            OrderItem = orderItem;
        }
        public OrderItemCommand(Operation operation, OrderItemDTO orderItem, OrderItemDTO2 orderItem2)
        {
            Operation = operation;
            OrderItem = orderItem;
            OrderItem2 = orderItem2;
        }
    }

}
