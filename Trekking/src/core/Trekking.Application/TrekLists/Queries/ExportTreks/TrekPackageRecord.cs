using Trekking.Application.Common.Mappings;
using Trekking.Domain.Entities;

namespace Trekking.Application.TrekLists.Queries.ExportTreks
{
    public class TrekPackageRecord : IMapFrom<TrekPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
