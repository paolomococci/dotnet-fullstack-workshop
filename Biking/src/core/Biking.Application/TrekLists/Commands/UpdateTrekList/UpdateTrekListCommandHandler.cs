using System.Threading;
using System.Threading.Tasks;
using Biking.Application.Common.Exceptions;
using Biking.Application.Common.Interfaces;
using MediatR;

namespace Biking.Application.TrekLists.Commands.UpdateTrekList
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
