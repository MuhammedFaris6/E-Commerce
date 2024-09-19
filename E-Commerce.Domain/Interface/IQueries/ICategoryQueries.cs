using E_Commerce.Domain.DTO;

namespace E_Commerce.Domain.Interface.IQueries
{
    public interface ICategoryQueries
    {
        IList<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int Id);
    }
}
