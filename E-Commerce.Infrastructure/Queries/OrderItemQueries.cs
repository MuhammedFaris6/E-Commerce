using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Queries
{
    public class OrderItemQueries : IOrderItemQueries
    {
        private readonly ECommerceDbcontext dbcontext;
        private readonly IMapper mapper;

        public OrderItemQueries(ECommerceDbcontext dbcontext, IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }
        public IList<OrderItemDTO> GetAllOrderItem()
        {
            return mapper.Map<IList<OrderItemDTO>>(dbcontext.orderItems.ToList());
        }

        public OrderItemDTO GetOrderItemById(int Id)
        {
            return mapper.Map<OrderItemDTO>(dbcontext.orderItems.FirstOrDefault(x => x.OrderItemId == Id));
        }
    }
}
