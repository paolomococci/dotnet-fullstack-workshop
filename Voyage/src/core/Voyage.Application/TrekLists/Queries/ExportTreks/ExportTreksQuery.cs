using MediatR;

namespace Voyage.Application.TrekLists.Queries.ExportTreks
{
    public class ExportTreksQuery : IRequest<ExportTreksVm>
    {
        public int ListId { get; set; }
    }
}
