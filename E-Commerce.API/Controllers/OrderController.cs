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
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IOrderQueries queries;

        public OrderController(IMediator mediator, IOrderQueries queries)
        {
            this.mediator = mediator;
            this.queries = queries;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO2 order2)
        {
            var order = new OrderDTO();
            var command = new OrderCommand(Operation.Create, order, order2);

            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var getorders = queries.GetAllOrder();
            return Ok(getorders);
        }
        [HttpGet("GetOrderById/{Id}")]
        public IActionResult GetOrderById(int Id)
        {
            var getorder = queries.GetOrderById(Id);
            if (getorder == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok(getorder);
        }
        [HttpPut("{Id}")]

        public async Task<IActionResult> UpdateOrder(int Id, [FromBody] OrderDTO2 order2)
        {
            var getorders = queries.GetOrderById(Id);
            if (getorders == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            var order = new OrderDTO { OrderId = Id };
            var command = new OrderCommand(Operation.Update, order, order2);
            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var getorder = queries.GetOrderById(Id);
            if (getorder == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            var order = new OrderDTO { OrderId = Id };
            var command = new OrderCommand(Operation.Delete, order);
            await mediator.Send(command);
            return Ok(new { message = "Order deleted successfully" });


        }
    }
}
