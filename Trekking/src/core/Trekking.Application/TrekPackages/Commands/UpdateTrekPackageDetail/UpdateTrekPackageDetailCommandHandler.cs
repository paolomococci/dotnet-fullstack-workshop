using System.Threading;
using System.Threading.Tasks;
using Trekking.Application.Common.Exceptions;
using Trekking.Application.Common.Interfaces;
using Trekking.Domain.Entities;
using MediatR;

namespace Trekking.Application.TrekPackages.Commands.UpdateTrekPackageDetail
{
    public class UpdateTrekPackageDetailCommandHandler : IRequestHandler<UpdateTrekPackageDetailCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public UpdateTrekPackageDetailCommandHandler(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;
        }

        public async Task<Unit> Handle(
            UpdateTrekPackageDetailCommand request,
            CancellationToken cancellationToken
        )
        {
            var entity = await _iApplicationDbContext.TrekPackages.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(
                    nameof(TrekPackage),
                    request.Id
                );
            }

            entity.Id = request.Id;
            entity.ListId = request.ListId;
            entity.Name = request.Name;
            entity.Hope = request.Hope;
            entity.MapLocation = request.MapLocation;
            entity.Price = request.Price;
            entity.Duration = request.Duration;
            entity.Confirmation = request.Confirmation;
            entity.Currency = request.Currency;

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
