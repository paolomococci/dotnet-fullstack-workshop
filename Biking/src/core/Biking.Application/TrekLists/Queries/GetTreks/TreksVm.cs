using System.Collections.Generic;
using Biking.Application.Dtos.Trek;

namespace Biking.Application.TrekLists.Queries.GetTreks
{
    public class TreksVm
    {
        public IList<TrekListDto> Lists { get; set; }
    }
}
