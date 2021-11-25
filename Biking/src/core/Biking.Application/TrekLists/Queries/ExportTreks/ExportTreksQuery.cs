using MediatR;

namespace Biking.Application.TrekLists.Queries.ExportTreks
{
    public class ExportTreksQuery : IRequest<ExportTreksVm>
    {
        public int ListId { get; set; }
    }
}
