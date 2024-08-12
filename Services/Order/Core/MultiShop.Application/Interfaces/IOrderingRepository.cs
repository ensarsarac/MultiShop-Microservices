using MultiShop.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Interfaces
{
    public interface IOrderingRepository
    {
        Task<List<Ordering>> GetListByUserId(string id);
    }
}
