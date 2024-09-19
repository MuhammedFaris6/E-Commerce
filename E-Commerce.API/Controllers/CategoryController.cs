using E_Commerce.Application.Commands;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using E_Commerce.Domain.Interface.IQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICategoryQueries queries;

        public CategoryController(IMediator mediator, ICategoryQueries queries)
        {
            this.mediator = mediator;
            this.queries = queries;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO2 category2)
        {
            var command = new CategoryCommand(Operation.Create, category2);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var getcategories = queries.GetAllCategories();
            return Ok(getcategories);
        }
        [HttpGet("GetCategoryById/{Id}")]
        public IActionResult GetCategoryById(int Id)
        {
            var getcategory = queries.GetCategoryById(Id);
            if (getcategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            return Ok(getcategory);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id, CategoryDTO2 category2)
        {
            var getcategory = queries.GetCategoryById(Id);
            if (getcategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            var category = new CategoryDTO { CategoryId = Id };
            var command = new CategoryCommand(Operation.Update, category, category2);
            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var getcategory = queries.GetCategoryById(Id);
            if (getcategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            var category = new CategoryDTO { CategoryId = Id };
            var command = new CategoryCommand(Operation.Delete, category);
            await mediator.Send(command);
            return Ok(new { message = "Category deleted successfully" });


        }
    }
}
