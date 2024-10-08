﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isactive,@validdate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isactive", createCouponDto.IsActive);
            parameters.Add("@validdate", createCouponDto.ValidDate);
            var context = _dapperContext.CreateConnection();
            await context.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponID=@couponid";
            var parameters = new DynamicParameters();
            parameters.Add("@couponid", id);
            var context = _dapperContext.CreateConnection();
            await context.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons";
            var context = _dapperContext.CreateConnection();
            var values = await context.QueryAsync<ResultDiscountCouponDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponID=@couponid";
            var parameters = new DynamicParameters();
            parameters.Add("@couponid", id);
            var context = _dapperContext.CreateConnection();
            var value= await context.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
            return value;
        }

        public async Task<GetDiscountCouponByCode> GetCouponCodeByCode(string code)
        {
            string query = "select * from Coupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            var context = _dapperContext.CreateConnection();
            var value = await context.QueryFirstOrDefaultAsync<GetDiscountCouponByCode>(query, parameters);
            return value;
        }

        public async Task<int> TotalCouponCount()
        {
            string query = "select count(*) from Coupons";
            var context = _dapperContext.CreateConnection();
            var values = await context.QueryFirstOrDefaultAsync<int>(query);
            return (int)values;
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code=@code,Rate=@rate,IsActive=@isactive,ValidDate=@validdate where CouponID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", updateCouponDto.CouponID);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isactive", updateCouponDto.IsActive);
            parameters.Add("@validdate", updateCouponDto.ValidDate);
            var context = _dapperContext.CreateConnection();
            await context.ExecuteAsync(query, parameters);
        }
    }
}
