using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly ECommerceDbcontext dbcontext;
        private readonly IMapper mapper;

        public OrderQueries(ECommerceDbcontext dbcontext, IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }
        public IList<OrderDTO> GetAllOrder()
        {
            var order = from orders in dbcontext.orders
                        join orderlist in dbcontext.orderItems
                        on orders.OrderId equals orderlist.OrderId into g
                        select new OrderDTO
                        {
                            OrderId = orders.OrderId,
                            CustomerId = orders.CustomerId,
                            OrderDate = orders.OrderDate,
                            TotalAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                        };
            return mapper.Map<IList<OrderDTO>>(order);
        }

        public OrderDTO GetOrderById(int Id)
        {
            return mapper.Map<OrderDTO>(dbcontext.orders.FirstOrDefault(x => x.OrderId == Id));
        }
    }
}
