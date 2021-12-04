using Cruises.Application.Common.Mappings;
using Cruises.Domain.Entities;

namespace Cruises.Application.CruiseLists.Queries.ExportCruises
{
  public class CruisePackageRecord
    : IMapFrom<CruisePackage>
  {
    public string Name { get; set; }
    public string MapLocation { get; set; }
  }
}
