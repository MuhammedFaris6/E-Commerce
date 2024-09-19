using AutoMapper;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface;
using MediatR;

namespace E_Commerce.Application.Commands
{
    /*public class CategoryCommandHandler : IRequestHandler<CategoryCommand, CategoryDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(CategoryCommand request, CancellationToken cancellationToken)
        {
            Category categoryEntity;
            switch (request.Operation)
            {
                case Operation.Create:
                    categoryEntity = new Category
                    {

                        CategoryName = request.Category2.CategoryName
                    };
                    var createdCategory = await repository.CreateCategoryAsync(categoryEntity);
                    return mapper.Map<CategoryDTO>(createdCategory);

                case Operation.Update:
                    var updatedEntity = new Category
                    {
                        CategoryId = request.Category.CategoryId,
                        CategoryName = request.Category2.CategoryName
                    };
                    await repository.UpdateCategoryteAsync(request.Category.CategoryId, updatedEntity);

                    return mapper.Map<CategoryDTO>(updatedEntity);

                case Operation.Delete:
                    await repository.DeleteCategoryByIdAsync(request.Category.CategoryId);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }*/
    public class CategoryCommandHandler : IRequestHandler<CategoryCommand, CategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<CategoryDTO> Handle(CategoryCommand request, CancellationToken cancellationToken)
        {
            Category Categoryentity;
            switch (request.Operation)
            {
                case Operation.Create:
                    Categoryentity = new Category
                    {/*
                        CategoryId = request.Category.CategoryId,*/
                        CategoryName = request.Category2.CategoryName
                    };
                    var createdcategory = await _repository.CreateCategoryAsync(Categoryentity);
                    return _mapper.Map<CategoryDTO>(createdcategory);

                case Operation.Update:
                    var updatedEntity = new Category
                    {
                        CategoryId = request.Category.CategoryId,
                        CategoryName = request.Category.CategoryName
                    };
                    await _repository.UpdateCategoryteAsync(request.Category.CategoryId, updatedEntity);

                    return _mapper.Map<CategoryDTO>(updatedEntity);

                case Operation.Delete:
                    await _repository.DeleteCategoryByIdAsync(request.Category.CategoryId);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


}
