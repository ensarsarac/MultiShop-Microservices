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
    public class UpdateOrderDetailHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailID);
            value.OrderingID = updateOrderDetailCommand.OrderingID;
            value.ProductAmount = updateOrderDetailCommand.ProductAmount;
            value.ProductID = updateOrderDetailCommand.ProductID;
            value.ProductName = updateOrderDetailCommand.ProductName;
            value.ProductPrice = updateOrderDetailCommand.ProductPrice;
            value.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            await _repository.UpdateAsync(value);

        }
    }
}
