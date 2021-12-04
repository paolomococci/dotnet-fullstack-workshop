using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Exceptions;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;

namespace Cruises.Application.CruisePackages.Commands.DeleteCruisePackage
{
  public class DeleteCruisePackageCommandHandler
    : IRequestHandler<DeleteCruisePackageCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public DeleteCruisePackageCommandHandler(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;
    }

    public async Task<Unit> Handle(
      DeleteCruisePackageCommand request,
      CancellationToken cancellationToken
    )
    {
      var cruisePackageEntity = await _iApplicationDbContext.CruisePackages
        .FindAsync(request.Id);

      if (cruisePackageEntity == null)
      {
        throw new NotFoundException(nameof(CruisePackage), request.Id);
      }

      _iApplicationDbContext.CruisePackages.Remove(cruisePackageEntity);

      await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
