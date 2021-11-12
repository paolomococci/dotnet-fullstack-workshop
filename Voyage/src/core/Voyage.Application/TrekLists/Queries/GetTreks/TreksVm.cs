using System.Collections.Generic;
using Voyage.Application.Dtos.Trek;

namespace Voyage.Application.TrekLists.Queries.GetTreks
{
    public class TreksVm
    {
        public IList<TrekListDto> Lists { get; set; }
    }
}
