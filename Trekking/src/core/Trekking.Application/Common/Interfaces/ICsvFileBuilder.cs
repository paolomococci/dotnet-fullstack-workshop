using System.Collections.Generic;
using Trekking.Application.TrekLists.Queries.ExportTreks;

namespace Trekking.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTrekPackagesFile(IEnumerable<TrekPackageRecord> records);
    }
}
