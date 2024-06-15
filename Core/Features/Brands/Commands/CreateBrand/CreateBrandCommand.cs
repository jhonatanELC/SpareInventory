using MediatR;

namespace Core.Features.Brands.Commands.CreateBrand
{
   public class CreateBrandCommand : IRequest<BrandToReturn>
   {
      public string brandName { get; set; }
   }
}
