using MediatR;

namespace Core.Features.Brands.Queries.GetBrands
{
   public class GetBrandsQuery: IRequest<IEnumerable<BrandResponse>>
   {
   }
}
