using Voyage.Application.Common.Mappings;
using Voyage.Domain.Entities;

namespace Voyage.Application.TrekLists.Queries.ExportTreks
{
    public class TrekPackageRecord : IMapFrom<TrekPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
