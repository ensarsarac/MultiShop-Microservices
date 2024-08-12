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
    public class GetAddressQueryResultHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryResultHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult()
            {
                AddressID = x.AddressID,
                City = x.City,
                Detail1 = x.Detail1,
                District = x.District,
                ZipCode = x.ZipCode,
                Surname = x.Surname,
                Phone = x.Phone,
                Name = x.Name,
                Email = x.Email,
                Detail2 = x.Detail2,
                Description = x.Description,
                Country = x.Country,
                UserId = x.UserId
            }).ToList();
        }
    }
}
