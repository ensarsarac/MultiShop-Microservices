using Microsoft.Extensions.DependencyInjection;
using MultiShop.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Application.Services
{
    public static class HandlerRegistration
    {
        public static void AddHandlersService(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryResultHandler>();
            services.AddScoped<GetAddressByIdQueryResultHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<DeleteAddressCommandHandler>();

            services.AddScoped<GetOrderDetailByIdQueryResultHandler>();
            services.AddScoped<GetOrderDetailQueryResultHandler>();
            services.AddScoped<CreateOrderDetailsHandler>();
            services.AddScoped<UpdateOrderDetailHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
        }
    }
}
