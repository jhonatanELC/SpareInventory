using Core.Contracts.Persistence;
using MediatR;
using Core.Domain.Entities;

namespace Core.Features.Vehicles.Commands.CreateVehicle
{
   public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, Guid?>
   {
      private readonly IVehicleRepository _vehicleRepository;

      public CreateVehicleHandler(IVehicleRepository vehicleRepository)
      {
         _vehicleRepository = vehicleRepository;
      }
      public async Task<Guid?> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
      {  
         bool existsBrandAndModel = await _vehicleRepository.ExistBrandAndModel(request.Brand, request.Model);

         if (existsBrandAndModel)
         {
            return null;
         }

         Vehicle v = new Vehicle()
         {
            VehicleId = Guid.NewGuid(),
            Brand = request.Brand,
            Model = request.Model,
            Year = request.Year
         };

         await _vehicleRepository.AddAsync(v);
         await _vehicleRepository.SaveChangesAsync();
         return v.VehicleId;
      }
   }
}

