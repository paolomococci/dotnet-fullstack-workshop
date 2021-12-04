using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Exceptions;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;

namespace Cruises.Application.CruisePackages.Commands.UpdateCruisePackage
{
  public class UpdateCruisePackageCommandHandler
    : IRequestHandler<UpdateCruisePackageCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public UpdateCruisePackageCommandHandler(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;
    }

    public async Task<Unit> Handle(
      UpdateCruisePackageCommand request,
      CancellationToken cancellationToken
    )
    {
      var cruisePackageEntity = await _iApplicationDbContext.CruisePackages.FindAsync(request.Id);

      if (cruisePackageEntity == null)
      {
        throw new NotFoundException(nameof(CruisePackage), request.Id);
      }

      cruisePackageEntity.Name = request.Name;

      await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
