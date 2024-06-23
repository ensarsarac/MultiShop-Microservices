using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Extension
{
	public static class ContainerDependency
	{
		public static void AddContainerDependency(this IServiceCollection services)
		{
			services.AddScoped<ICargoCompanyDal, EfCargoCompanyRepository>();
			services.AddScoped<ICargoCompanyService,CargoCompanyManager>();

			services.AddScoped<ICargoCustomerDal, EfCargoCustomerRepository>();
			services.AddScoped<ICargoCustomerService,CargoCustomerManager>();

			services.AddScoped<ICargoDetailDal, EfCargoDetailRepository>();
			services.AddScoped<ICargoDetailService,CargoDetailManager>();

			services.AddScoped<ICargoOperationsDal, EfCargoOperationRepository>();
			services.AddScoped<ICargoOperationsService,CargoOperationManager>();
		}
	}
}
