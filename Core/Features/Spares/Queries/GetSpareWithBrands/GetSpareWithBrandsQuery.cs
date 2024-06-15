using Core.Models;
using MediatR;

namespace Core.Features.Spares.Queries.GetSpareWithBrands
{
   public class GetSpareWithBrandsQuery : IRequest<SpareToReturn?>
   {
      public Guid SpareId { get; set; }
   }
}
