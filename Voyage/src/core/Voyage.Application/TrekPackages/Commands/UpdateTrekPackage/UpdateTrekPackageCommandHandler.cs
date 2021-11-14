using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Voyage.Application.TrekPackages.Commands.UpdateTrekPackage
{
    public class UpdateTrekPackageCommandHandler : IRequestHandler<UpdateTrekPackageCommand>
    {
        public Task<Unit> Handle(UpdateTrekPackageCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
