using Core.Services.BrandService.Commands.Create;

namespace Core.Contracts.Service.Brand
{
    public interface IBrandGetService
    {   
        /// <summary>
        /// Get a brand by Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        Task<BrandToReturn?> GetBrandById(Guid brandId);

        /// <summary>
        /// Get all brands
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<BrandToReturn>> GetBrands();
    }
}
