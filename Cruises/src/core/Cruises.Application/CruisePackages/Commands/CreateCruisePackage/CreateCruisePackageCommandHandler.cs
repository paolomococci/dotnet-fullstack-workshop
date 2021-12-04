using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;

namespace Cruises.Application.CruisePackages.Commands.CreateCruisePackage
{
  public class CreateCruisePackageCommandHandler
    : IRequestHandler<CreateCruisePackageCommand, int>
  {

    private readonly IApplicationDbContext _iApplicationDbContext;

    public CreateCruisePackageCommandHandler(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;
    }

    public async Task<int> Handle(
      CreateCruisePackageCommand request,
      CancellationToken cancellationToken
    )
    {
      var cruisePackageEntity = new CruisePackage
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

      _iApplicationDbContext.CruisePackages.Add(cruisePackageEntity);

      await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

      return cruisePackageEntity.Id;
    }
  }
}
