using MultiShop.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryResultHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryResultHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailsQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetOrderDetailsQueryResult()
            {
                OrderDetailID = x.OrderDetailID,
                OrderingID = x.OrderingID,
                ProductAmount = x.ProductAmount,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
            }).ToList();
        }
    }
}
