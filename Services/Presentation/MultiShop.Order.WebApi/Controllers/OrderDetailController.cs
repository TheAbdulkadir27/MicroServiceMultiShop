using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandler;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailByIDQueryHandler _getByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getorderdetailqueryhandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler;
        public OrderDetailController(GetOrderDetailByIDQueryHandler getByIdQueryHandler, GetOrderDetailQueryHandler getorderdetailqueryhandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getByIdQueryHandler = getByIdQueryHandler;
            _getorderdetailqueryhandler = getorderdetailqueryhandler;
            this.createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            this.updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            this.removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getorderdetailqueryhandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var value = await _getByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.OrderDetailQueries.GetOrderDetailQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await createOrderDetailCommandHandler.Handle(command);
            return Ok("Order Detail Başarıyla Kaydedildi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await updateOrderDetailCommandHandler.Handle(command);
            return Ok("Order Detail Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Başarıyla Order Detail Silindi");
        }
    }
}
