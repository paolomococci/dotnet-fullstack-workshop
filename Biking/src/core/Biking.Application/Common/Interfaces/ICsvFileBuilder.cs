using System.Collections.Generic;
using Biking.Application.TrekLists.Queries.ExportTreks;

namespace Biking.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTrekPackagesFile(IEnumerable<TrekPackageRecord> records);
    }
}
