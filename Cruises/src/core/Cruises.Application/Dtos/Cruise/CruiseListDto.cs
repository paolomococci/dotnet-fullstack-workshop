using System.Collections.Generic;
using Cruises.Application.Common.Mappings;
using Cruises.Domain.Entities;

namespace Cruises.Application.Dtos.Cruise
{
  public class CruiseListDto
    : IMapFrom<CruiseList>
  {
    public IList<CruisePackageDto> Items { get; set; }
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }

    public CruiseListDto()
    {
      Items = new List<CruisePackageDto>();
    }
  }
}
