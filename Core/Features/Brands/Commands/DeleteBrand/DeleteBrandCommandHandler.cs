using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Brands.Commands.DeleteBrand
{
   public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
   {
      private readonly IBrandRepository _brandRepository;

      public DeleteBrandCommandHandler(IBrandRepository brandRepository)
      {
         _brandRepository = brandRepository;
      }

      /// <summary>
      /// Handles the delete brand command
      /// </summary>
      /// <param name="request"></param>
      /// <param name="cancellationToken"></param>
      /// <returns> True if the brand was deleted</returns>
      public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
      {
         Brand? brand =  await _brandRepository.GetByIdAsync(request.brandId);

         if (brand is null) return false;

         _brandRepository.Delete(brand);
         await _brandRepository.SaveChangesAsync();
         return true;
      }
   }
}
