using Core.Contracts.Persistence;
using Core.Contracts.Service.Spare;
using Core.Dtos.SpareDto;
using Core.Domain.Entities;
using AutoMapper;


namespace Core.Services.SpareService
{
    public class SpareAddService : ISpareAddService
    {
        private IGenericRepository<Spare> _genericRepository { get; }
        private IMapper _mapper { get; }

        public SpareAddService(IGenericRepository<Spare> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        // TODO 2: Implement validations
        public async Task<SpareToReturn> AddSpare(SpareToAdd spareToAddDto)
        {
            Spare spare = _mapper.Map<Spare>(spareToAddDto);

            await _genericRepository.AddAsync(spare);
            await _genericRepository.SaveChangesAsync();

            SpareToReturn spareToReturn = _mapper.Map<SpareToReturn>(spare);

            return spareToReturn;
        }
    }
}
