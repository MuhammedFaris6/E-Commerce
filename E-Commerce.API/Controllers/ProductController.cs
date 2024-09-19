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
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IProductQueries queries;

        public ProductController(IMediator mediator, IProductQueries queries)
        {
            this.mediator = mediator;
            this.queries = queries;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO2 product2)
        {
            var product = new ProductDTO();
            var command = new ProductCommand(Operation.Create, product, product2);

            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var getproducts = queries.GetAllProducts();
            return Ok(getproducts);
        }
        [HttpGet("GetProductById/{Id}")]
        public IActionResult GetProductById(int Id)
        {
            var getproduct = queries.GetProductById(Id);
            if (getproduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(getproduct);
        }
        [HttpPut("{Id}")]

        public async Task<IActionResult> UpdateProduct(int Id, [FromBody] ProductDTO2 product2)
        {
            var getproducts = queries.GetProductById(Id);
            if (getproducts == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            var product = new ProductDTO { ProductId = Id };
            var command = new ProductCommand(Operation.Update, product, product2);
            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var getproduct = queries.GetProductById(Id);
            if (getproduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            var product = new ProductDTO { ProductId = Id };
            var command = new ProductCommand(Operation.Delete, product);
            await mediator.Send(command);
            return Ok(new { message = "Product deleted successfully" });


        }
    }
}
