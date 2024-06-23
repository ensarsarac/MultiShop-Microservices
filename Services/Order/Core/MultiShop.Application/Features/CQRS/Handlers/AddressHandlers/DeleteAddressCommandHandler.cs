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
    public class DeleteAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAddressCommand deleteAddressCommand)
        {
            var value = await _repository.GetByIdAsync(deleteAddressCommand.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
