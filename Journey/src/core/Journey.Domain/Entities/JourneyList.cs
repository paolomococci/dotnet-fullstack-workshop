using System.Collections.Generic;

namespace Journey.Domain.Entities
{
    public class JourneyList
    {
        public JourneyList()
        {
            Trips = new List<JourneySelection>();
        }

        public IList<JourneySelection> Trips { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
