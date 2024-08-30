using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getaddressQueryHandler;
        private readonly GetAddressByIDQueryHandler getAddressByIDQueryHandler;
        private readonly CreateAddressCommandHandler createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler removeAddressCommand;
        public AddressController(GetAddressQueryHandler getaddressQueryHandler, GetAddressByIDQueryHandler getAddressByIDQueryHandler, CreateAddressCommandHandler createAddressCommandHandler = null, UpdateAddressCommandHandler updateAddressCommandHandler = null, RemoveAddressCommandHandler removeAddressCommand = null)
        {
            _getaddressQueryHandler = getaddressQueryHandler;
            this.getAddressByIDQueryHandler = getAddressByIDQueryHandler;
            this.createAddressCommandHandler = createAddressCommandHandler;
            this.updateAddressCommandHandler = updateAddressCommandHandler;
            this.removeAddressCommand = removeAddressCommand;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getaddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values = await getAddressByIDQueryHandler.Handle(new GetAddressByIDQuery(id));
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddress command)
        {
            await createAddressCommandHandler.Handle(command);
            return Ok("Address Bilgisi Başarıyla EKlendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddress command)
        {
            await updateAddressCommandHandler.Handle(command);
            return Ok("Address Bilgisi Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await removeAddressCommand.Handle(new RemoveAddress(id));
            return Ok("Address Verisi Başarıyla Silindi");
        }
    }
}
