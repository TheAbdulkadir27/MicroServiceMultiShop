using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIDQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressByIDQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIDQueryResult> Handle(GetAddressByIDQuery query)
        {
            var values = await _repository.GetByIDAsync(query.id);
            return new GetAddressByIDQueryResult()
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserID = values.UserID
            };
        }
    }
}
