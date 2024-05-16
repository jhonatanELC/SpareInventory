using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareService;
using Core.Domain.Entities;

namespace Core.Services.SpareService.Commands.Delete
{
    public class SpareDeleteService : ISpareDeleteService
    {
        private readonly IGenericRepository<Spare> _genericRepository;

        public SpareDeleteService(IGenericRepository<Spare> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Spare?> DeleteSpare(Guid spareId)
        {
            if (!await _genericRepository.ExistsEntityAsync(e => e.SpareId == spareId))
            {
                return null;
            }

            Spare? spare = await _genericRepository.GetByIdAsync(spareId);

            _genericRepository.DeleteAsync(spare!);
            await _genericRepository.SaveChangesAsync();

            return spare;
        }
    }
}
