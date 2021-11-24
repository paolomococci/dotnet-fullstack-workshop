using System.Collections.Generic;

namespace Biking.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTrekPackagesFile(IEnumerable<TrekPackageRecord> records);
    }
}
