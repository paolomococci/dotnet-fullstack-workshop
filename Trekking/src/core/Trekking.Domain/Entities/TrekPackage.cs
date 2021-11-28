using Trekking.Domain.Enums;

namespace Trekking.Domain.Entities
{
    public class TrekPackage
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Hope { get; set; }
        public string MapLocation { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public bool Confirmation { get; set; }
        public Currency Currency { get; set; }
        public TrekList TrekList { get; set; }
    }
}
