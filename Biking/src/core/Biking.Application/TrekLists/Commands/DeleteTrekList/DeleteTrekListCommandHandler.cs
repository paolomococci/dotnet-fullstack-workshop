using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Biking.Application.Common.Exceptions;
using Biking.Application.Common.Interfaces;
using MediatR;

namespace Biking.Application.TrekLists.Commands.DeleteTrekList
{
    public class DeleteTrekListCommandHandler : IRequestHandler<DeleteTrekListCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public DeleteTrekListCommandHandler(IApplicationDbContext context)
        {
            _iApplicationDbContext = context;
        }

        public async Task<Unit> Handle(
            DeleteTrekListCommand request, CancellationToken cancellationToken
        )
        {
            var entity = await _iApplicationDbContext.TrekLists.Where(
                trekList => trekList.Id == request.Id
            ).SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TrekList), request.Id);
            }

            _iApplicationDbContext.TrekLists.Remove(entity);

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
