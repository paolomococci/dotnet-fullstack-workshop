using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Application.Common.Interfaces;
using Voyage.Application.Dtos.Trek;

namespace Voyage.Application.TrekLists.Queries.GetTreks
{
    public class GetTreksQueryHandler : IRequestHandler<GetTreksQuery, TreksVm>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;
        private readonly IMapper _iMapper;

        public GetTreksQueryHandler(
            IApplicationDbContext context,
            IMapper mapper
        )
        {
            _iApplicationDbContext = context;
            _iMapper = mapper;
        }

        public async Task<TreksVm> Handle(GetTreksQuery request, CancellationToken cancellationToken)
        {
            return new TreksVm
            {
                Lists = await _iApplicationDbContext
                    .TrekLists
                    .ProjectTo<TrekListDto>(_iMapper.ConfigurationProvider)
                    .OrderBy(trekListDto => trekListDto.City)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
