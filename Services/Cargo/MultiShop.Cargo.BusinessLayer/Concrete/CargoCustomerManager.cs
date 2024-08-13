using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
	public class CargoCustomerManager : ICargoCustomerService
	{
		private readonly ICargoCustomerDal _cargoCustomerDal;

		public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
		{
			_cargoCustomerDal = cargoCustomerDal;
		}

		public void TDelete(int id)
		{
			_cargoCustomerDal.Delete(id);
		}

		public CargoCustomer TGetById(int id)
		{
			return _cargoCustomerDal.GetById(id);
		}

        public async Task<ResultCargoCustomerByUserId> TGetCargoCustomerByUserId(string id)
        {
			return await _cargoCustomerDal.GetCargoCustomerByUserId(id);
        }

        public List<CargoCustomer> TGetList()
		{
			return _cargoCustomerDal.GetList();
		}

		public void TInsert(CargoCustomer entity)
		{
			_cargoCustomerDal.Insert(entity);
		}

		public void TUpdate(CargoCustomer entity)
		{
			_cargoCustomerDal.Update(entity);
		}
	}
}
