using MultiShop.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var value = await _repository.GetByIdAsync(updateAddressCommand.AddressID);
            value.Detail = updateAddressCommand.Detail;
            value.City = updateAddressCommand.City;
            value.District = updateAddressCommand.District;
            value.UserId = updateAddressCommand.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
