using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Service.AboutServices;
using MultiShop.Catalog.Service.BrandServices;
using MultiShop.Catalog.Service.ContactServices;
using MultiShop.Catalog.Service.FeatureServices;
using MultiShop.Catalog.Service.FeatureSliderServices;
using MultiShop.Catalog.Service.OfferDiscountServices;
using MultiShop.Catalog.Service.SpecialOfferServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceCatalog";
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailsService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // automapper

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); // appsettings.json içerisinde ki configurationlar.

builder.Services.AddScoped<IDatabaseSettings>(ds =>
{
    return ds.GetRequiredService<IOptions<DatabaseSettings>>().Value; // DatabaseSetting içerisinde ki value ulaþacak.
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
