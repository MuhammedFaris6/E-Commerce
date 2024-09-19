using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class OrderCommand : IRequest<OrderDTO>
    {
        public Operation Operation { get; }
        public OrderDTO Order { get; set; }
        public OrderDTO2 Order2 { get; set; }

        public OrderCommand(Operation operation, OrderDTO order)
        {
            Operation = operation;
            Order = order;
        }
        public OrderCommand(Operation operation, OrderDTO order, OrderDTO2 order2)
        {
            Operation = operation;
            Order = order;
            Order2 = order2;
        }
    }
}
