﻿using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserID = x.UserID
            }).ToList();
        }
    }
}
