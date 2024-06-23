using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingQueryResult:IRequest<List<GetOrderingQueryResult>>
    {
        public int OrderingID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
