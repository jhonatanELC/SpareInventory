using AutoMapper;
using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Brands.Queries.GetBrands
{
   public class GetBrandsHandler : IRequestHandler<GetBrandsQuery, IEnumerable<BrandResponse>>
   {
      private readonly IBrandRepository _brandRepository;
      private readonly IMapper _mapper;

      public GetBrandsHandler(IBrandRepository brandRepository, IMapper mapper)
      {
         _brandRepository = brandRepository;
         _mapper = mapper;
      }
      public async Task<IEnumerable<BrandResponse>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
      {
         IEnumerable<Brand> brands = await _brandRepository.ListAllAsync();

         return _mapper.Map<IEnumerable<BrandResponse>>(brands);
      }
   }
}