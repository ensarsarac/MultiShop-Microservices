﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Service.BrandServices
{
    public class BrandService:IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // veritabanı
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName); // tablo
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var value = await _brandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(value);
        }


        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var value = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, value);
        }
    }
}
