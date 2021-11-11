using System.Collections.Generic;
using Voyage.Application.TrekLists.Queries.ExportTreks;

namespace Voyage.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTrekPackagesFile(IEnumerable<TrekPackageRecord> records);
    }
}
