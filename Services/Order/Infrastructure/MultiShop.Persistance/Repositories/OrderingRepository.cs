using Microsoft.EntityFrameworkCore;
using MultiShop.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Application.Interfaces;
using MultiShop.Domain.Entities;
using MultiShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Persistance.Repositories
{
	public class OrderingRepository : IOrderingRepository
	{
		private readonly OrderContext _context;

		public OrderingRepository(OrderContext context)
		{
			_context = context;
		}
		public async Task<List<Ordering>> GetListByUserId(string id)
		{
			var values = await _context.Orderings.Where(x => x.UserID == id).ToListAsync();
			return values;
		}
	}
}
