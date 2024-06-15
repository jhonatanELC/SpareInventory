using Core.Models;
using MediatR;

namespace Core.Features.Spares.Queries.GetSparesWithBrands
{
   public class GetSparesWithBrandsQuery : IRequest<IEnumerable<SpareToReturn>>
   {
      public string? searchByOemCode { get; set; }
      public string? searchrBySku { get; set; }
      public string? searchByDescription { get; set; }
      public string? filterByGroup { get; set; }
   }
}
