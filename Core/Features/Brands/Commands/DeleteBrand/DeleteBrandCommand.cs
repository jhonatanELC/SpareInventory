using MediatR;

namespace Core.Features.Brands.Commands.DeleteBrand
{
   public class DeleteBrandCommand : IRequest<bool>
   {
      public Guid brandId { get; set; }
   }
}
