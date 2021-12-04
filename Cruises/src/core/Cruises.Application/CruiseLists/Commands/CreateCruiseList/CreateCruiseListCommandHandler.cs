using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using MediatR;

namespace Cruises.Application.CruiseLists.Commands.CreateCruiseList
{
  public class CreateCruiseListCommandHandler
    : IRequestHandler<CreateCruiseListCommand, int>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public CreateCruiseListCommandHandler(IApplicationDbContext context)
    {
      _iApplicationDbContext = context;
    }

    public async Task<int> Handle(
      CreateCruiseListCommand request,
      CancellationToken cancellationToken
    )
    {
      var cruiseListEntity = new CruiseList
      {
        City = request.City
      };

      _iApplicationDbContext.CruiseLists.Add(cruiseListEntity);

      await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

      return cruiseListEntity.Id;
    }
  }
}
