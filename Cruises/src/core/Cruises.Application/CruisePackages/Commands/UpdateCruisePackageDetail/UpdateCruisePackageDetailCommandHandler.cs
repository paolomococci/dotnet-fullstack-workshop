using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Exceptions;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;

namespace Cruises.Application.CruisePackages.Commands.UpdateCruisePackageDetail
{
  public class UpdateCruisePackageDetailCommandHandler
    : IRequestHandler<UpdateCruisePackageDetailCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public UpdateCruisePackageDetailCommandHandler(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;
    }

    public async Task<Unit> Handle(
      UpdateCruisePackageDetailCommand request,
      CancellationToken cancellationToken
    )
    {
      var entity = await _iApplicationDbContext.CruisePackages.FindAsync(request.Id);

      if (entity == null)
      {
        throw new NotFoundException(
            nameof(CruisePackage),
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
