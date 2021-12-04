using System.Collections.Generic;
using Cruises.Application.CruiseLists.Queries.ExportCruises;

namespace Cruises.Application.Common.Interfaces
{
  public interface ICsvFileBuilder
  {
    byte[] BuildCruisePackagesFile(IEnumerable<CruisePackageRecord> records);
  }
}
