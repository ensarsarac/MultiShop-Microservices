using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
	public class EfCargoCompanyRepository:GenericRepository<CargoCompany>,ICargoCompanyDal
	{
        public EfCargoCompanyRepository(CargoContext context):base(context)
        {
            
        }
    }
}
