using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Voyage.Application.TrekPackages.Commands.UpdateTrekPackageDetail
{
    public class UpdateTrekPackageDetailCommandHandler : IRequestHandler<UpdateTrekPackageDetailCommand>
    {
        public Task<Unit> Handle(
            UpdateTrekPackageDetailCommand request,
            CancellationToken cancellationToken
        )
        {
            throw new System.NotImplementedException();
        }
    }
}
