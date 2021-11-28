using MediatR;

namespace Trekking.Application.TrekLists.Queries.ExportTreks
{
    public class ExportTreksQuery : IRequest<ExportTreksVm>
    {
        public int ListId { get; set; }
    }
}
