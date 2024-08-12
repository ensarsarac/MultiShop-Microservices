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
            value.Detail1 = updateAddressCommand.Detail1;
            value.Phone = updateAddressCommand.Phone;
            value.Name = updateAddressCommand.Name;
            value.Email = updateAddressCommand.Email;
            value.Detail2 = updateAddressCommand.Detail2;
            value.Description = updateAddressCommand.Description;
            value.Country = updateAddressCommand.Country;
            value.UserId = updateAddressCommand.UserId;
            value.Surname = updateAddressCommand.Surname;
            value.Name = updateAddressCommand.Name;
            value.ZipCode = updateAddressCommand.ZipCode;
            value.City = updateAddressCommand.City;
            value.District = updateAddressCommand.District;
            value.UserId = updateAddressCommand.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
