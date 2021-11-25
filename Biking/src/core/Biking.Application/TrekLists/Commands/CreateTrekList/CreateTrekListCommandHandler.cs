using System.Threading;
using System.Threading.Tasks;
using Biking.Application.Common.Interfaces;
using Biking.Domain.Entities;
using MediatR;

namespace Biking.Application.TrekLists.Commands
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
