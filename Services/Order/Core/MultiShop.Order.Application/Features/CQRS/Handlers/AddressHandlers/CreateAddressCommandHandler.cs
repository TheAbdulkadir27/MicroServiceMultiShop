using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddress createAddress)
        {
            await _repository.CreateAsync(new Address()
            {
                City = createAddress.City,
                Detail = createAddress.Detail,
                District = createAddress.District,
                UserID = createAddress.UserID,
            });
        }
    }
}
