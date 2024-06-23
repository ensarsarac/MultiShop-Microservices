using MultiShop.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryResultHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryResultHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
            return new GetAddressByIdQueryResult()
            {
                AddressID = value.AddressID,
                City = value.City,
                Detail = value.Detail,
                District = value.District,
                UserId = value.UserId
            };
        }
    }
}
