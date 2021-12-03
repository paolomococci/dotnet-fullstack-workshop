using System.Collections.Generic;

namespace Cruises.Domain.Entities
{
  public class CruiseList
  {
    public CruiseList()
    {
      CruisePackages = new List<CruisePackage>();
    }

    public IList<CruisePackage> CruisePackages { get; set; }
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
  }
}
