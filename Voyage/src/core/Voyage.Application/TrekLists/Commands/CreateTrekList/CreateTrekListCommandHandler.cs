using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Application.Common.Interfaces;
using Voyage.Domain.Entities;

namespace Voyage.Application.TrekLists.Commands.CreateTrekList
{
    public class CreateTrekListCommandHandler : IRequestHandler<CreateTrekListCommand, int>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public CreateTrekListCommandHandler(IApplicationDbContext context)
        {
            _iApplicationDbContext = context;
        }

        public async Task<int> Handle(
            CreateTrekListCommand request,
            CancellationToken cancellationToken
        )
        {
            var trekListEntity = new TrekList
            {
                City = request.City
            };

            _iApplicationDbContext.TrekLists.Add(trekListEntity);

            await _iApplicationDbContext.SaveChangesAsync(cancellationToken);

            return trekListEntity.Id;
        }
    }
}
