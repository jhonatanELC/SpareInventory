using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareService;
using Core.Domain.Entities;
using Core.Dtos.Filters;
using Core.Dtos.SpareDto;

namespace Core.Services.SpareService
{
    public class SpareGetService : ISpareGetService
    {
        private readonly IGenericRepository<Spare> _genericRepository;
        private readonly IMapper _mapper;
        private readonly ISpareRepository _spareRepository;

        public SpareGetService(IGenericRepository<Spare> genericRepository, IMapper mapper, ISpareRepository spareRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _spareRepository = spareRepository;
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

        public async Task<IReadOnlyList<SpareWithBrandToReturn>> GetSparesWithBrands(SpareFilter filter)
        {
            IReadOnlyList<Spare> spares = await _spareRepository.GetSparesWithBrandsAsync(filter);

            return _mapper.Map<IReadOnlyList<SpareWithBrandToReturn>>(spares);
        }
    }
}
