using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;

namespace E_Commerce.Application.Commands
{
    public class CategoryCommand : IRequest<CategoryDTO>
    {
        public Operation Operation { get; }
        public CategoryDTO Category { get; set; }
        public CategoryDTO2 Category2 { get; set; }

        public CategoryCommand(Operation operation, CategoryDTO2 category2)
        {
            Operation = operation;
            Category2 = category2;
        }
        public CategoryCommand(Operation operation, CategoryDTO category, CategoryDTO2 category2)
        {
            Operation = operation;
            Category = category;
            Category2 = category2;
        }
        public CategoryCommand(Operation operation, CategoryDTO category)
        {
            Operation = operation;
            Category = category;

        }
    }

}
