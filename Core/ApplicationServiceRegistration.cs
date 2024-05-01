using Core.Contracts.Service.Brand;
using Core.Contracts.Service.SpareService;
using Core.Contracts.Service.SpareBrandService;
using Core.Services.BrandService;
using Core.Services.SpareBrandService;
using Core.Services.SpareService;
using Microsoft.Extensions.DependencyInjection;
using Core.Contracts.Service.PriceService;
using Core.Services.PriceService;
using Core.Contracts.Service.Vehicle;
using Core.Services.VehicleService;

namespace Core
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Spare
            services.AddScoped<ISpareAddService, SpareAddService>();
            services.AddScoped<ISpareGetService, SpareGetService>();
            services.AddScoped<ISpareDeleteService, SpareDeleteService>();

            // Brand
            services.AddScoped<IBrandAddService, BrandAddService>();
            services.AddScoped<IBrandGetService, BrandGetService>();

            // SpareBrand
            services.AddScoped<ISpareBrandAddService, SpareBrandAddService>();

            // Price
            services.AddScoped<IPriceAddService, PriceAddService>();
            services.AddScoped<IPriceUpdateService, PriceUpdateService>();

            // Vehicle
            services.AddScoped<IVehicleAddService, VehicleAddService>();
            services.AddScoped<IVehicleGetService, VehicleGetService>();

            return services;
        }
    }
}
