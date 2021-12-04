using MediatR;

namespace Cruises.Application.CruiseLists.Queries.ExportCruises
{
  public class ExportCruisesQuery
    : IRequest<ExportCruisesVm>
  {
    public int ListId { get; set; }
  }
}
