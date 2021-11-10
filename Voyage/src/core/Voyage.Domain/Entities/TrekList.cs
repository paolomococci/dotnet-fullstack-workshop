using System.Collections.Generic;

namespace Voyage.Domain.Entities
{
    public class TrekList
    {
        public TrekList()
        {
            TrekPackages = new List<TrekPackage>();
        }

        public IList<TrekPackage> TrekPackages { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
