using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cruises.Application.Common.Interfaces;
using Cruises.Application.Dtos.Cruise;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.CruiseLists.Queries.GetCruises
{
  public class GetCruisesQueryHandler
    : IRequestHandler<GetCruisesQuery, CruisesVm>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;
    private readonly IMapper _iMapper;

    public GetCruisesQueryHandler(
      IApplicationDbContext context,
      IMapper mapper
    )
    {
      _iApplicationDbContext = context;
      _iMapper = mapper;
    }

    public async Task<CruisesVm> Handle(
      GetCruisesQuery request,
      CancellationToken cancellationToken
    )
    {
      return new CruisesVm
      {
        Lists = await _iApplicationDbContext
          .CruiseLists
            .ProjectTo<CruiseListDto>(_iMapper.ConfigurationProvider)
            .OrderBy(cruiseListDto => cruiseListDto.City)
            .ToListAsync(cancellationToken)
      };
    }
  }
}
