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
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IOrderItemQueries queries;

        public OrderItemController(IMediator mediator, IOrderItemQueries queries)
        {
            this.mediator = mediator;
            this.queries = queries;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OrderItemDTO2 orderItem2)
        {
            var orderItem = new OrderItemDTO();
            var command = new OrderItemCommand(Operation.Create, orderItem, orderItem2);

            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            var getorderItems = queries.GetAllOrderItem();
            return Ok(getorderItems);
        }
        [HttpGet("GetOrderItemById/{Id}")]
        public IActionResult GetOrderItemById(int Id)
        {
            var getorderItem = queries.GetOrderItemById(Id);
            if (getorderItem == null)
            {
                return NotFound(new { message = "OrderItem not found" });
            }
            return Ok(getorderItem);
        }
        [HttpPut("{Id}")]

        public async Task<IActionResult> UpdateOrderItem(int Id, [FromBody] OrderItemDTO2 orderItem2)
        {
            var getorderItems = queries.GetOrderItemById(Id);
            if (getorderItems == null)
            {
                return NotFound(new { message = "OrderItem not found" });
            }
            var orderItem = new OrderItemDTO { OrderItemId = Id };
            var command = new OrderItemCommand(Operation.Update, orderItem, orderItem2);
            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOrderItem(int Id)
        {
            var getorderItem = queries.GetOrderItemById(Id);
            if (getorderItem == null)
            {
                return NotFound(new { message = "OrderItem not found" });
            }
            var orderItem = new OrderItemDTO { OrderItemId = Id };
            var command = new OrderItemCommand(Operation.Delete, orderItem);
            await mediator.Send(command);
            return Ok(new { message = "OrderItem deleted successfully" });


        }
    }
}
