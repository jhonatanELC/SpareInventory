using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.Vehicle;
using Core.Domain.Entities;

namespace Core.Services.VehicleService.Commands.Create
{
    public class VehicleAddService : IVehicleAddService
    {
        private readonly IGenericRepository<Vehicle> _genericRepository;
        private readonly IMapper _mapper;

        public VehicleAddService(IGenericRepository<Vehicle> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<VehicleToReturn> AddVehicle(VehicleToAdd vehicleToAdd)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleToAdd);

            await _genericRepository.AddAsync(vehicle);
            await _genericRepository.SaveChangesAsync();

            VehicleToReturn vehicleToReturn = _mapper.Map<VehicleToReturn>(vehicle);

            return vehicleToReturn;
        }
    }
}
