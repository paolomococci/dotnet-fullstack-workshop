using System.Collections.Generic;
using Voyage.Application.Common.Mappings;
using Voyage.Domain.Entities;

namespace Voyage.Application.Dtos.Trek
{
    public class TrekListDto : IMapFrom<TrekList>
    {
        public IList<TrekPackageDto> Items { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public TrekListDto()
        {
            Items = new List<TrekPackageDto>();
        }
    }
}
