using System.Collections.Generic;
using Trekking.Application.Dtos.Trek;

namespace Trekking.Application.TrekLists.Queries.GetTreks
{
    public class TreksVm
    {
        public IList<TrekListDto> Lists { get; set; }
    }
}
