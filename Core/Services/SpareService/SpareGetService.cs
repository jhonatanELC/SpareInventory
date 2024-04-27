using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.Spare;
using Core.Domain.Entities;
using Core.Dtos.SpareDto;

namespace Core.Services.SpareService
{
    public class SpareGetService : ISpareGetService
    {
        private readonly IGenericRepository<Spare> _genericRepository;
        private readonly IMapper _mapper;

        public SpareGetService(IGenericRepository<Spare> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<SpareToReturn?> GetSpareById(Guid spareId)
        {
            Spare? spare =  await _genericRepository.GetByIdAsync(spareId);

            if (spare == null)
            {
                return null;
            }

            return _mapper.Map<SpareToReturn>(spare);
        }

        public async Task<IReadOnlyList<SpareToReturn>> GetSpares()
        {
            IReadOnlyList<Spare>  spares=  await _genericRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<SpareToReturn>>(spares);
        }
    }
}
