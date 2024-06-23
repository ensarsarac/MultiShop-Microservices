using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
	public class CargoOperationManager : ICargoOperationsService
	{
		private readonly ICargoOperationsDal _cargoOperationsDal;

		public CargoOperationManager(ICargoOperationsDal cargoOperationsDal)
		{
			_cargoOperationsDal = cargoOperationsDal;
		}
		public void TDelete(int id)
		{
			_cargoOperationsDal.Delete(id);
		}

		public CargoOperation TGetById(int id)
		{
			return _cargoOperationsDal.GetById(id);
		}

		public List<CargoOperation> TGetList()
		{
			return _cargoOperationsDal.GetList();
		}

		public void TInsert(CargoOperation entity)
		{
			_cargoOperationsDal.Insert(entity);
		}

		public void TUpdate(CargoOperation entity)
		{
			_cargoOperationsDal.Update(entity);
		}
	}
}
