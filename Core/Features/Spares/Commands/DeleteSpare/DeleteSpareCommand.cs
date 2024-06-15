using MediatR;

namespace Core.Features.Spares.Commands.DeleteSpare
{
    public class DeleteSpareCommand : IRequest<bool>
    {
        public Guid SpareId { get; set; }
    }
}
