using API.Middleware;
using Core;
using Infrastructure;
namespace API
{
   public static class StartupExtensions
   {
      public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
      {
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

         // Adds my own services
         builder.Services.AddCoreServiceCollection();
         builder.Services.AddPersistenceServices(builder.Configuration);

         builder.Services.AddControllers().AddNewtonsoftJson(options =>
         {
            options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
         });


         return builder.Build();
      }

      public static WebApplication ConfigurePipeline(this WebApplication app)
      {
         app.UseMiddleware<ExceptionMiddleware>();

         // Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();

         app.UseAuthorization();

         app.MapControllers();

         return app;
      }

   }
}
