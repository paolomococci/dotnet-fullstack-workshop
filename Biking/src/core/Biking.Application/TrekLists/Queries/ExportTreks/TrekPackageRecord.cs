using Biking.Application.Common.Mappings;
using Biking.Domain.Entities;

namespace Biking.Application.TrekLists.Queries.ExportTreks
{
    public class TrekPackageRecord : IMapFrom<TrekPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
