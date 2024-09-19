using E_Commerce.Application.Commands;
using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IWebHostEnvironment environment;

        public ProductImageController(IMediator mediator, IWebHostEnvironment environment)
        {
            this.mediator = mediator;
            this.environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(ProductImageDTO2 productimage2)
        {
            if (string.IsNullOrEmpty(productimage2.ImagePath))
            {
                return BadRequest("path is required");
            }

            var ImagePath = Path.Combine(environment.ContentRootPath, productimage2.ImagePath);
            if (!System.IO.File.Exists(ImagePath))
            {
                return BadRequest("image does not exists");
            }
            byte[] image;
            using (var File = new FileStream(ImagePath, FileMode.Open, FileAccess.Read))
            {
                using (var memoryStream = new MemoryStream())
                {
                    File.CopyTo(memoryStream);
                    image = memoryStream.ToArray();
                }
            }
            var productimage = new ProductImageDTO();
            productimage.Image = image;

            var command = new ProductImageCommand(Operation.Create, productimage, productimage2);

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
