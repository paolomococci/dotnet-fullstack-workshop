using MediatR;

namespace Cruises.Application.CruiseLists.Queries.GetCruises
{
  public class GetCruisesQuery
    : IRequest<CruisesVm>
  { }
}
