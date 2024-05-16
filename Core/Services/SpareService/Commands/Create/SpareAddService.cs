using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareService;
using Core.Domain.Entities;
using AutoMapper;


namespace Core.Services.SpareService.Commands.Create
{
   public class SpareAddService : ISpareAddService
   {
      private readonly ISpareRepository _spareRepository;
      private readonly IGenericRepository<SpareBrand> _genericSpareBrandRepository;
      private readonly IGenericRepository<Price> _genericPriceRepository;
      private readonly IGenericRepository<Brand> _genericBrandRepository;
      private IGenericRepository<Spare> _genericRepository;
      private IMapper _mapper;

      public SpareAddService(IGenericRepository<Spare> genericSpareRepository, IMapper mapper, ISpareRepository spareRepository, IGenericRepository<SpareBrand> genericSpareBrandRepository, IGenericRepository<Price> genericPriceRepository,
         IGenericRepository<Brand> genericBrandRepository
         )
      {
         _genericRepository = genericSpareRepository;
         _mapper = mapper;
         _spareRepository = spareRepository;
         _genericSpareBrandRepository = genericSpareBrandRepository;
         _genericPriceRepository = genericPriceRepository;
         _genericBrandRepository = genericBrandRepository;
      }

      // TODO 2: Implement validations
      public async Task<SpareVmToReturn> AddSpare(SpareToAdd spareToAddDto)
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
         SpareVmToReturn spareToReturn = _mapper.Map<SpareVmToReturn>(spare);

         return spareToReturn;
      }

      public async Task<SpareVmToReturn> AddSpareWithBrand(SpareWithBrandToAdd spareToAdd)
      {
         SpareVmToReturn sparetoReturn = new();

         bool existSku = await _spareRepository.ExistSku(spareToAdd.Sku);

         // Validations
         if (existSku) throw new InvalidOperationException("The Sku code already exists");

         var validator = new SpareAddValidator();
         var validationResult = await validator.ValidateAsync(spareToAdd);

         if (validationResult.Errors.Count > 0)
         {
            sparetoReturn.Success = false;
            sparetoReturn.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
               sparetoReturn.ValidationErrors.Add(error.ErrorMessage);
            }
         }
         if (sparetoReturn.Success)
         {
            // Mapping
            Spare spare = _mapper.Map<Spare>(spareToAdd);
            Price price = _mapper.Map<Price>(spareToAdd);
            SpareBrand spareBrand = _mapper.Map<SpareBrand>(spareToAdd);

            // Add vehicleId if exits
            spare.VehicleId = spareToAdd.VehicleId != null ? spareToAdd.VehicleId : null;

            // Create Spare
            await _genericRepository.AddAsync(spare);

            // Get brand
            Brand? brand = await _genericBrandRepository.GetByIdAsync(spareToAdd.BrandId);

            // Add Brand to Spare
            if (brand == null) throw new InvalidOperationException("The brandId doesn't exist!");

            spare.Brands.Add(brand);

            spareBrand.SpareId = spare.SpareId;
            spareBrand.BrandId = brand.BrandId;
            await _genericSpareBrandRepository.AddAsync(spareBrand);

            // Add Price
            price.SpareBrandId = spareBrand.SpareBrandId;
            await _genericPriceRepository.AddAsync(price);

            await _genericPriceRepository.SaveChangesAsync();


            sparetoReturn = _mapper.Map<SpareVmToReturn>(spare);

         }


         return sparetoReturn;
      }

   }
}
