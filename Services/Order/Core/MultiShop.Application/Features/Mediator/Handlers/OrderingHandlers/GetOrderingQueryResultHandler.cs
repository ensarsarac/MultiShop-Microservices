using MediatR;
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
    public class GetOrderingQueryResultHandler : IRequestHandler<GetOrderingQueryResult, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryResultHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult()
            {
                OrderDate = x.OrderDate,
                OrderingID = x.OrderingID,
                TotalPrice = x.TotalPrice,
                UserID = x.UserID,
            }).ToList();
        }
    }
}
