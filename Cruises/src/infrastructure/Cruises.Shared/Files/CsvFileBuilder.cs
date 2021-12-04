using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Cruises.Application.Common.Interfaces;
using Cruises.Application.CruiseLists.Queries.ExportCruises;
using CsvHelper;

namespace Cruises.Shared.Files
{
  public class CsvFileBuilder
    : ICsvFileBuilder
  {
    public byte[] BuildCruisePackagesFile(
      IEnumerable<CruisePackageRecord> records
    )
    {
      using var memoryStream = new MemoryStream();

      using (var streamWriter = new StreamWriter(memoryStream))
      {
        using var csvWriter = new CsvWriter(
            streamWriter,
            CultureInfo.InvariantCulture
        );
        csvWriter.WriteRecords(records);
      }

      return memoryStream.ToArray();
    }
  }
}
