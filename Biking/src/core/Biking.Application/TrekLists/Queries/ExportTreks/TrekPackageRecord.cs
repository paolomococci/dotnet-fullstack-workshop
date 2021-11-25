using Biking.Application.Common.Mappings;

namespace Biking.Application.TrekLists.Queries.ExportTreks
{
    public class TrekPackageRecord : IMapFrom<TrekPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
