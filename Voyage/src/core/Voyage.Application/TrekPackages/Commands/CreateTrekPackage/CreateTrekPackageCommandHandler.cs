using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Voyage.Application.Common.Interfaces;
using Voyage.Domain.Entities;

namespace Voyage.Application.TrekPackages.Commands.CreateTrekPackage
{
    public class CreateTrekPackageCommandHandler : IRequestHandler<CreateTrekPackageCommand, int>
    {

        private readonly IApplicationDbContext _iApplicationDbContext;

        public CreateTrekPackageCommandHandler(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;
        }

        public async Task<int> Handle(
            CreateTrekPackageCommand request,
            CancellationToken cancellationToken
        )
        {
            var trekPackageEntity = new TrekPackage
            {
                ListId = request.ListId,
                Name = request.Name,
                Hope = request.Hope,
                MapLocation = request.MapLocation,
                Price = request.Price,
                Duration = request.Duration,
                Confirmation = request.Confirmation,
                Currency = request.Currency
            };

            _iApplicationDbContext.TrekPackages.Add(trekPackageEntity);

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return trekPackageEntity.Id;
        }
    }
}
