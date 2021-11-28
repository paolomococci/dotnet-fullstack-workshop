using System.Threading;
using System.Threading.Tasks;
using Trekking.Application.Common.Exceptions;
using Trekking.Application.Common.Interfaces;
using Trekking.Domain.Entities;
using MediatR;

namespace Trekking.Application.TrekLists.Commands.UpdateTrekList
{
    public class UpdateTrekListCommandHandler : IRequestHandler<UpdateTrekListCommand>
    {

        private readonly IApplicationDbContext _iApplicationDbContext;

        public UpdateTrekListCommandHandler(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;
        }

        public async Task<Unit> Handle(
            UpdateTrekListCommand request,
            CancellationToken cancellationToken
        )
        {
            var trekListEntity = await _iApplicationDbContext.TrekLists.FindAsync(request.Id);

            if (trekListEntity == null)
            {
                throw new NotFoundException(nameof(TrekList), request.Id);
            }

            trekListEntity.City = request.City;

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
