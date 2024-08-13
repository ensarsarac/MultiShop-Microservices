using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
	public interface ICargoCustomerDal:IGenericDal<CargoCustomer>
	{
		Task<ResultCargoCustomerByUserId> GetCargoCustomerByUserId(string id);
	}
}
