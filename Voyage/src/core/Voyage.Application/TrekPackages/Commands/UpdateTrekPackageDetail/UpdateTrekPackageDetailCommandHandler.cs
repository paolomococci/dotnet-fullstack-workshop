using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Voyage.Application.Common.Exceptions;
using Voyage.Application.Common.Interfaces;
using Voyage.Domain.Entities;

namespace Voyage.Application.TrekPackages.Commands.UpdateTrekPackageDetail
{
    public class UpdateTrekPackageDetailCommandHandler : IRequestHandler<UpdateTrekPackageDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTrekPackageDetailCommandHandler(
            IApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<Unit> Handle(
            UpdateTrekPackageDetailCommand request,
            CancellationToken cancellationToken
        )
        {
            var entity = await _context.TrekPackages.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TrekPackage), request.Id);
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

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
