using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Exceptions;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.CruiseLists.Commands.DeleteCruiseList
{
  public class DeleteCruiseListCommandHandler
    : IRequestHandler<DeleteCruiseListCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public DeleteCruiseListCommandHandler(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;
    }

    public async Task<Unit> Handle(
      DeleteCruiseListCommand request,
      CancellationToken cancellationToken
    )
    {
      var entity = await _iApplicationDbContext.CruiseLists.Where(
        cruiseList => cruiseList.Id == request.Id
      ).SingleOrDefaultAsync(cancellationToken);

      if (entity == null)
      {
        throw new NotFoundException(
          nameof(CruiseList),
          request.Id
        );
      }

      _iApplicationDbContext.CruiseLists.Remove(entity);

      await _iApplicationDbContext.SaveChangesAsync(
        cancellationToken
      );

      return Unit.Value;
    }
  }
}
