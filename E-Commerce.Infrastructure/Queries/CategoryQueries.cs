using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Queries
{
    public class CategoryQueries : ICategoryQueries
    {
        private readonly ECommerceDbcontext dbcontext;
        private readonly IMapper mapper;

        public CategoryQueries(ECommerceDbcontext dbcontext, IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }
        public IList<CategoryDTO> GetAllCategories()
        {
            return mapper.Map<IList<CategoryDTO>>(dbcontext.categories.ToList());
        }

        public CategoryDTO GetCategoryById(int Id)
        {
            return mapper.Map<CategoryDTO>(dbcontext.categories.FirstOrDefault(c => c.CategoryId == Id));

        }
    }
}
