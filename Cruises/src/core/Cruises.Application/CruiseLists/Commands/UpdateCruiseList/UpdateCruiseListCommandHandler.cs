using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Exceptions;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;

namespace Cruises.Application.CruiseLists.Commands.UpdateCruiseList
{
  public class UpdateCruiseListCommandHandler
    : IRequestHandler<UpdateCruiseListCommand>
  {

    private readonly IApplicationDbContext _iApplicationDbContext;

    public UpdateCruiseListCommandHandler(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;
    }

    public async Task<Unit> Handle(
      UpdateCruiseListCommand request,
      CancellationToken cancellationToken
    )
    {
      var cruiseListEntity = await _iApplicationDbContext
        .CruiseLists.FindAsync(request.Id);

      if (cruiseListEntity == null)
      {
        throw new NotFoundException(
          nameof(CruiseList),
          request.Id
        );
      }

      cruiseListEntity.City = request.City;

      await _iApplicationDbContext.SaveChangesAsync(
        cancellationToken
      );

      return Unit.Value;
    }
  }
}
