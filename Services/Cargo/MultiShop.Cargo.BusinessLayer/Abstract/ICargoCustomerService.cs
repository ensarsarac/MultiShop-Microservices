﻿using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
	public interface ICargoCustomerService:IGenericService<CargoCustomer>
	{
        Task<ResultCargoCustomerByUserId> TGetCargoCustomerByUserId(string id);
    }
}
