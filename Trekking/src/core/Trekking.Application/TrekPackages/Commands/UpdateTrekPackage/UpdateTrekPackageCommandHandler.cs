using System.Threading;
using System.Threading.Tasks;
using Trekking.Application.Common.Exceptions;
using Trekking.Application.Common.Interfaces;
using Trekking.Domain.Entities;
using MediatR;

namespace Trekking.Application.TrekPackages.Commands.UpdateTrekPackage
{
    public class UpdateTrekPackageCommandHandler : IRequestHandler<UpdateTrekPackageCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public UpdateTrekPackageCommandHandler(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;
        }

        public async Task<Unit> Handle(
            UpdateTrekPackageCommand request,
            CancellationToken cancellationToken
        )
        {
            var trekPackageEntity = await _iApplicationDbContext.TrekPackages.FindAsync(request.Id);

            if (trekPackageEntity == null)
            {
                throw new NotFoundException(nameof(TrekPackage), request.Id);
            }

            trekPackageEntity.Name = request.Name;

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
