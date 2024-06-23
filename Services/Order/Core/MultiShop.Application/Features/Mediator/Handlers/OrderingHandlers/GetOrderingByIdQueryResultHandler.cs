using MediatR;
using MultiShop.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryResultHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryResultHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult()
            {
                OrderDate = value.OrderDate,
                OrderingID = value.OrderingID,
                TotalPrice = value.TotalPrice,
                UserID = value.UserID
            };
        }
    }
}
