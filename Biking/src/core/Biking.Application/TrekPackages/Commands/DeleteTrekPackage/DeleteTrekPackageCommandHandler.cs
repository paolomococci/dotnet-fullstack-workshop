using System.Threading;
using System.Threading.Tasks;
using Biking.Application.Common.Exceptions;
using Biking.Application.Common.Interfaces;
using MediatR;

namespace Biking.Application.TrekPackages.Commands.DeleteTrekPackage
{
    public class DeleteTrekPackageCommandHandler : IRequestHandler<DeleteTrekPackageCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public DeleteTrekPackageCommandHandler(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;
        }

        public async Task<Unit> Handle(
            DeleteTrekPackageCommand request,
            CancellationToken cancellationToken
        )
        {
            var trekPackageEntity = await _iApplicationDbContext.TrekPackages.FindAsync(request.Id);

            if (trekPackageEntity == null)
            {
                throw new NotFoundException(nameof(TrekPackage), request.Id);
            }

            _iApplicationDbContext.TrekPackages.Remove(trekPackageEntity);

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
