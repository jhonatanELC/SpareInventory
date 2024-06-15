using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Spares.Commands.DeleteSpare
{
   public class DeleteSpareCommandHandler : IRequestHandler<DeleteSpareCommand, bool>
   {
      private readonly ISpareRepository _spareRepository;

      public DeleteSpareCommandHandler(ISpareRepository spareRepository)
      {
         _spareRepository = spareRepository;
      }
      public async Task<bool> Handle(DeleteSpareCommand request, CancellationToken cancellationToken)
      {
         Spare? spare = await _spareRepository.GetByIdAsync(request.SpareId);

         if(spare != null)
         {
            _spareRepository.Delete(spare);
            await _spareRepository.SaveChangesAsync();
            return true;
         }
         return false;
      }
   }
}
