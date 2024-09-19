using E_Commerce.Domain.DTO;

namespace E_Commerce.Domain.Interface.IQueries
{
    public interface IOrderQueries
    {
        IList<OrderDTO> GetAllOrder();
        OrderDTO GetOrderById(int Id);
    }
}
