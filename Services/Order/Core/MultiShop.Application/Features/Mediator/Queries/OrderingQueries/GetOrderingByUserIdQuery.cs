using MediatR;
using MultiShop.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.Mediator.Queries.OrderingQueries
{
	public class GetOrderingByUserIdQuery:IRequest<List<GetOrderingByUserIdQueryResult>>
	{
        public string UserId { get; set; }
    }
}
