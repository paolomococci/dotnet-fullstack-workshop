using System.Collections.Generic;
using Cruises.Application.Dtos.Cruise;

namespace Cruises.Application.CruiseLists.Queries.GetCruises
{
  public class CruisesVm
  {
    public IList<CruiseListDto> Lists { get; set; }
  }
}
