using E_Commerce.Domain.DTO;

namespace E_Commerce.Domain.Interface.IQueries
{
    public interface IProductQueries
    {
        IList<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int Id);
    }
}
