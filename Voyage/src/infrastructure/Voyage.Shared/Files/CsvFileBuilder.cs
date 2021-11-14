using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Voyage.Application.Common.Interfaces;
using Voyage.Application.TrekLists.Queries.ExportTreks;

namespace Voyage.Shared.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTrekPackagesFile(IEnumerable<TrekPackageRecord> records)
        {
            using var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
