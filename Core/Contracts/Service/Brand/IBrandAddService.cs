using Core.Dtos.BrandDto;

namespace Core.Contracts.Service.Brand
{
    public interface IBrandAddService
    {   
        /// <summary>
        /// Add a Brand
        /// </summary>
        /// <param name="brandName">The name of the brand</param>
        /// <returns>A Brand</returns>
        Task<BrandToReturn> AddBrand(string brandName);

    }
}
