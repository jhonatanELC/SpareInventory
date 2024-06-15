using AutoMapper;
using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Brands.Commands.CreateBrand
{
   internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandToReturn>
   {
      private readonly IBrandRepository _brandRepository;
      private readonly IMapper _mapper;

      public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
      {
         _brandRepository = brandRepository;
         _mapper = mapper;
      }
      public async Task<BrandToReturn> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
      {
         Brand brand = new();
         brand.Name = request.brandName;

         await _brandRepository.AddAsync(brand);
         await _brandRepository.SaveChangesAsync();

         BrandToReturn brandToReturn = _mapper.Map<BrandToReturn>(brand);

         return brandToReturn;
      }
   }
}
