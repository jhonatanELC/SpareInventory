using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Core
{
   public static class ApplicationServiceRegistration
   {
      public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services)
      {
         services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
         services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

         // Spare
         //services.AddScoped<ISpareAddService, SpareAddService>();
         //services.AddScoped<ISpareGetService, SpareGetService>();
         //services.AddScoped<ISpareDeleteService, SpareDeleteService>();

         // Brand
         //services.AddScoped<IBrandAddService, BrandAddService>();
         //services.AddScoped<IBrandGetService, BrandGetService>();

         // SpareBrand
         //services.AddScoped<ISpareBrandAddService, SpareBrandAddService>();

         // Price
         //services.AddScoped<IPriceAddService, PriceAddService>();
         //services.AddScoped<IPriceUpdateService, PriceUpdateService>();

         // Vehicle
         //services.AddScoped<IVehicleAddService, VehicleAddService>();
         //services.AddScoped<IVehicleGetService, VehicleGetService>();

         return services;
      }
   }
}
