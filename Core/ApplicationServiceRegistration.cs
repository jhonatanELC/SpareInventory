using Core.Contracts.Service.Brand;
using Core.Contracts.Service.Spare;
using Core.Contracts.Service.SpareBrand;
using Core.Services.BrandService;
using Core.Services.SpareBrandService;
using Core.Services.SpareService;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ISpareAddService, SpareAddService>();
            services.AddScoped<ISpareGetService, SpareGetService>();
            services.AddScoped<IBrandAddService, BrandAddService>();
            services.AddScoped<ISpareBrandAddService, SpareBrandAddService>();
            return services;
        }
    }
}
