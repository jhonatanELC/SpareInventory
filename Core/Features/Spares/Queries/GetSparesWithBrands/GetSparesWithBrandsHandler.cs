using AutoMapper;
using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Core.Extentions;
using Core.Models;
using MediatR;

namespace Core.Features.Spares.Queries.GetSparesWithBrands
{
   public class GetSparesWithBrandsHandler : IRequestHandler<GetSparesWithBrandsQuery, IEnumerable<SpareToReturn>>
   {
      private readonly ISpareRepository _spareRepository;
      private readonly IMapper _mapper;

      public GetSparesWithBrandsHandler(ISpareRepository spareRepository, IMapper mapper)
      {
         _spareRepository = spareRepository;
         _mapper = mapper;
      }
      public async Task<IEnumerable<SpareToReturn>> Handle(GetSparesWithBrandsQuery request, CancellationToken cancellationToken)
      {    
         IReadOnlyList<Spare> spares = await _spareRepository.GetSparesWithBrandsAsync(request);

         return spares.Select(s => s.ToSpareResponse());          
      }
   }
}
