using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Core.Extentions;
using Core.Models;
using MediatR;

namespace Core.Features.Spares.Queries.GetSpareWithBrands
{
   public class GetSpareWithBrandsHandler : IRequestHandler<GetSpareWithBrandsQuery, SpareToReturn?>
   {
      private readonly ISpareRepository _spareRepository;

      public GetSpareWithBrandsHandler(ISpareRepository spareRepository)
      {
         _spareRepository = spareRepository;
      }
      public async Task<SpareToReturn?> Handle(GetSpareWithBrandsQuery request, CancellationToken cancellationToken)
      {
         Spare? spare = await _spareRepository.GetSpareWithBrands(request.SpareId);

         if(spare!=null) return spare.ToSpareResponse();

         return null;
      }
   }
}
