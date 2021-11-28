using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Trekking.Application.Common.Interfaces;
using Trekking.Application.TrekLists.Queries.ExportTreks;
using CsvHelper;

namespace Trekking.Shared.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTrekPackagesFile(
            IEnumerable<TrekPackageRecord> records
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
