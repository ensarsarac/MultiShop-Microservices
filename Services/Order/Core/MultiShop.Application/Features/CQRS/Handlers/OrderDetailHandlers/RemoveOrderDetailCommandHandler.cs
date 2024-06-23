using MultiShop.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(removeOrderDetailCommand.Id));
        }
    }
}
