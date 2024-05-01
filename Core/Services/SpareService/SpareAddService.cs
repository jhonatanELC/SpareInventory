using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareService;
using Core.Dtos.SpareDto;
using Core.Domain.Entities;
using AutoMapper;


namespace Core.Services.SpareService
{
    public class SpareAddService : ISpareAddService
    {
        private readonly ISpareRepository _spareRepository;
        private IGenericRepository<Spare> _genericRepository { get; }
        private IMapper _mapper { get; }

        public SpareAddService(IGenericRepository<Spare> genericRepository, IMapper mapper, ISpareRepository spareRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _spareRepository = spareRepository;
        }

        // TODO 2: Implement validations
        public async Task<SpareToReturn> AddSpare(SpareToAdd spareToAddDto)
        {
            // Check if the OEM code already exists
            bool existsOemCode = await _spareRepository.ExistOemCode(spareToAddDto.OemCode);

            if (existsOemCode) throw new InvalidOperationException("The OEM code already exists");

            // Mapping
            Spare spare = _mapper.Map<Spare>(spareToAddDto);

            // Save the entity
            await _genericRepository.AddAsync(spare);
            await _genericRepository.SaveChangesAsync();

            // Mapping
            SpareToReturn spareToReturn = _mapper.Map<SpareToReturn>(spare);

            return spareToReturn;
        }
    }
}
