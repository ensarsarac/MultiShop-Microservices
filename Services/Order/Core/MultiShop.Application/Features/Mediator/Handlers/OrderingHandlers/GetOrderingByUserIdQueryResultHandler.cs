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
	public class GetOrderingByUserIdQueryResultHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
	{
		private readonly IOrderingRepository _repository;

		public GetOrderingByUserIdQueryResultHandler(IOrderingRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetListByUserId(request.UserId);
			return values.Select(x => new GetOrderingByUserIdQueryResult()
			{
				OrderDate = x.OrderDate,
				OrderingID = x.OrderingID,
				TotalPrice = x.TotalPrice,
				UserID = x.UserID,
			}).ToList();
		}
	}
}
