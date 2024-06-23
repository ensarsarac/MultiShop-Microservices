using MultiShop.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetOrderDetailByIdQueryResultHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryResultHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            return new GetOrderDetailByIdQueryResult()
            {
                OrderDetailID = value.OrderDetailID,
                OrderingID = value.OrderingID,
                ProductAmount = value.ProductAmount,
                ProductID = value.ProductID,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductTotalPrice = value.ProductTotalPrice,
            };


        }
    }
}
