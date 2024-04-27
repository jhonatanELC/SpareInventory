using Core.Contracts.Persistence;
using Core.Contracts.Service.Spare;
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
            return services;
        }
    }
}
