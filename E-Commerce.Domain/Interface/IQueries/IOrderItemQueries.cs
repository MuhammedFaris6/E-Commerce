using E_Commerce.Domain.DTO;

namespace E_Commerce.Domain.Interface.IQueries
{
    public interface IOrderItemQueries
    {
        IList<OrderItemDTO> GetAllOrderItem();
        OrderItemDTO GetOrderItemById(int Id);
    }
}
