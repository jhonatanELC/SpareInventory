using AutoMapper;
using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Spares.Commands.CreateSpare
{
   internal class CreateSpareHandler : IRequestHandler<CreateSpareCommand, SpareVmToReturn>
   {
      private readonly IMapper _mapper;
      private readonly ISpareRepository _spareRepository;
      private readonly IBrandRepository _brandRepository;
      private readonly ISpareBrandRepository _spareBrandRepository;
      private readonly IPriceRepository _priceRepository;

      public CreateSpareHandler(IMapper mapper, ISpareRepository spareRepository, IBrandRepository brandRepository, ISpareBrandRepository spareBrandRepository, IPriceRepository priceRepository)
      {
         _mapper = mapper;
         _spareRepository = spareRepository;
         _brandRepository = brandRepository;
         _spareBrandRepository = spareBrandRepository;
         _priceRepository = priceRepository;
      }
      public async Task<SpareVmToReturn> Handle(CreateSpareCommand request, CancellationToken cancellationToken)
      {
         SpareVmToReturn sparetoReturn = new();

         var validator = new CreateSpareValidator();
         var validationResult = await validator.ValidateAsync(request);

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
            Spare spare = _mapper.Map<Spare>(request);
            Price price = _mapper.Map<Price>(request);
            SpareBrand spareBrand = _mapper.Map<SpareBrand>(request);
            Brand? brand;
            // Add vehicleId if exits
            spare.VehicleId = request.VehicleId != null ? request.VehicleId : null;

            // Check if sku exists
            bool existsSku = await _spareBrandRepository.ExistsSku(request.Sku);
            if (existsSku) throw new InvalidOperationException($"The sku: {request.Sku} already exists!");

            // Add spare to brand
            bool existsBrand = await _brandRepository.ExistsEntityAsync(b => b.BrandId == request.BrandId);
            bool existsOemCode = await _spareRepository.ExistOemCode(request.OemCode);

            if(!existsBrand) throw new InvalidOperationException("The brandId doesn't exist!");

            if (!existsOemCode)
            {
               // Create Spare
               await _spareRepository.AddAsync(spare);
               // Get brand
               brand = await _brandRepository.GetByIdAsync(request.BrandId);
               spare.Brands.Add(brand);

               // Add Brand to Spare
               if (await _spareBrandRepository.ExistsBrandIdSpareIdAsync(spare.SpareId, brand.BrandId)) throw new InvalidOperationException($"The's already a spareId: {spare.SpareId} with this brandId: {brand.BrandId}");

               spareBrand.SpareId = spare.SpareId;
               spareBrand.BrandId = brand.BrandId;
               await _spareBrandRepository.AddAsync(spareBrand);

               // Add Price
               price.SpareBrandId = spareBrand.SpareBrandId;
               await _priceRepository.AddAsync(price);

               await _spareRepository.SaveChangesAsync();
               sparetoReturn = _mapper.Map<SpareVmToReturn>(spare);
            }
            else 
            {
               Spare? spareFromDb = await _spareRepository.GetSpareByOemCode(request.OemCode);
               // Get brand
               brand = await _brandRepository.GetByIdAsync(request.BrandId);
               if(spareFromDb != null) spareFromDb.Brands.Add(brand);

               // Add Brand to Spare
               if (await _spareBrandRepository.ExistsBrandIdSpareIdAsync(spareFromDb.SpareId, brand.BrandId)) throw new InvalidOperationException($"The's already a spareId: {spare.SpareId} with this brandId: {brand.BrandId}");

               spareBrand.SpareId = spareFromDb.SpareId;
               spareBrand.BrandId = brand.BrandId;
               await _spareBrandRepository.AddAsync(spareBrand);

               // Add Price
               price.SpareBrandId = spareBrand.SpareBrandId;
               await _priceRepository.AddAsync(price);

               await _spareRepository.SaveChangesAsync();
               sparetoReturn = _mapper.Map<SpareVmToReturn>(spareFromDb);
            }
         }
         return sparetoReturn;
      }
   }
}
