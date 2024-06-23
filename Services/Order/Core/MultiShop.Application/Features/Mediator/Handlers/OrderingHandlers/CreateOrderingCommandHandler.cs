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
    public class CreateOrderingCommandHandler: IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering()
            {
                UserID = request.UserID,
                TotalPrice = request.TotalPrice,
                OrderDate = request.OrderDate,

            });
        }
    }
}
