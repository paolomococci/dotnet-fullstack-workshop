using System.Collections.Generic;
using Voyage.Application.Common.Interfaces;
using Voyage.Application.TrekLists.Queries.ExportTreks;

namespace Voyage.Shared.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTrekPackagesFile(IEnumerable<TrekPackageRecord> records)
        {
            throw new System.NotImplementedException();
        }
    }
}
