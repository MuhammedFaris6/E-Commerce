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
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICustomerQueries queries;
        private readonly IWebHostEnvironment environment;

        public CustomerController(IMediator mediator, ICustomerQueries queries, IWebHostEnvironment environment)
        {
            this.mediator = mediator;
            this.queries = queries;
            this.environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDTO2 customer2)
        {
            if (string.IsNullOrEmpty(customer2.ImagePath))
            {
                return BadRequest("path is required");
            }

            var ImagePath = Path.Combine(environment.ContentRootPath, customer2.ImagePath);
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
            var customer = new CustomerDTO();
            customer.ProfilePhoto = image;
            var command = new CustomerCommand(Operation.Create, customer, customer2);

            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var getcustomers = queries.GetAllCustomers();
            return Ok(getcustomers);
        }
        [HttpGet("GetCustomerById/{Id}")]
        public IActionResult GetCustomerById(int Id)
        {
            var getcustomer = queries.GetCustomerById(Id);
            if (getcustomer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }
            return Ok(getcustomer);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCustomery(int Id, [FromBody] CustomerDTO2 customer2)
        {
            var getcustomers = queries.GetCustomerById(Id);
            if (getcustomers == null)
            {
                return NotFound(new { message = "Customer not found" });
            }
            if (string.IsNullOrEmpty(customer2.ImagePath))
            {
                return BadRequest("path is required");
            }

            var ImagePath = Path.Combine(environment.ContentRootPath, customer2.ImagePath);
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
            var customer = new CustomerDTO { CustomerId = Id };
            customer.ProfilePhoto = image;
            var command = new CustomerCommand(Operation.Update, customer, customer2);
            var result = await mediator.Send(command);
            return Ok(result);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var getcustomer = queries.GetCustomerById(Id);
            if (getcustomer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }
            var customer = new CustomerDTO { CustomerId = Id };
            var command = new CustomerCommand(Operation.Delete, customer);
            await mediator.Send(command);
            return Ok(new { message = "Customer deleted successfully" });


        }
    }
}
