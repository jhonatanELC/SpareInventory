using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.Vehicle;
using Core.Domain.Entities;
using Core.Dtos.VehicleDto;

namespace Core.Services.VehicleService
{
    public class VehicleGetService : IVehicleGetService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Vehicle> _genericRepository;

        public VehicleGetService(IMapper mapper, IGenericRepository<Vehicle> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<IReadOnlyList<VehicleToReturn>> GetVehicles()
        {
            var vehicle = await _genericRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<VehicleToReturn>>(vehicle);
        }
    }
}
