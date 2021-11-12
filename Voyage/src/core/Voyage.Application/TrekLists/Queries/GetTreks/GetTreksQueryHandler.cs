using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Voyage.Application.TrekLists.Queries.GetTreks
{
    public class GetTreksQueryHandler : IRequestHandler<GetTreksQuery, TreksVm>
    {
        public Task<TreksVm> Handle(GetTreksQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
