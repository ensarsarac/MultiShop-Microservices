using MediatR;
using MultiShop.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderingID);
            value.OrderDate = request.OrderDate;
            value.TotalPrice = request.TotalPrice;
            value.UserID = request.UserID;
            await _repository.UpdateAsync(value);
        }
    }
}
