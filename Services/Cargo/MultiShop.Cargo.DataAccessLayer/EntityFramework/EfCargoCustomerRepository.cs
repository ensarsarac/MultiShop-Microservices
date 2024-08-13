using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
	public class EfCargoCustomerRepository: GenericRepository<CargoCustomer>, ICargoCustomerDal
	{
        private readonly CargoContext _context;
		public EfCargoCustomerRepository(CargoContext context) : base(context)
		{
            _context = context;
		}

        public async Task<ResultCargoCustomerByUserId> GetCargoCustomerByUserId(string id)
        {
            var values = await _context.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefaultAsync();

            return new ResultCargoCustomerByUserId
            {
                Address = values.Address,
                CargoCustomerId = values.CargoCustomerId,
                City = values.City,
                District = values.District,
                Email = values.Email,
                Name = values.Name,
                PhoneNumber = values.PhoneNumber,
                Surname = values.Surname,
                UserCustomerId = values.UserCustomerId
            };
        }
    }
}
