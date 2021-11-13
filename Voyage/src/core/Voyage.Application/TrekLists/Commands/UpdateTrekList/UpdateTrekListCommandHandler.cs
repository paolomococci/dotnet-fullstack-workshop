using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Voyage.Application.TrekLists.Commands.UpdateTrekList
{
    public class UpdateTrekListCommandHandler : IRequestHandler<UpdateTrekListCommand>
    {
        public Task<Unit> Handle(UpdateTrekListCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
