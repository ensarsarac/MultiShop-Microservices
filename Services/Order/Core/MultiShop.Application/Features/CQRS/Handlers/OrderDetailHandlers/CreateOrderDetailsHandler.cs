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
    public class CreateOrderDetailsHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailsHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail()
            {
                OrderingID = createOrderDetailCommand.OrderingID,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductID = createOrderDetailCommand.ProductID,
                ProductName = createOrderDetailCommand.ProductName,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
            });
        }
    }
}
