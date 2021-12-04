using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cruises.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.CruiseLists.Queries.ExportCruises
{
  public class ExportCruisesQueryHandler
    : IRequestHandler<ExportCruisesQuery, ExportCruisesVm>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;
    private readonly IMapper _iMapper;
    private readonly ICsvFileBuilder _iCsvFileBuilder;

    public ExportCruisesQueryHandler(
      IApplicationDbContext context,
      IMapper mapper,
      ICsvFileBuilder fileBuilder
    )
    {
      _iApplicationDbContext = context;
      _iMapper = mapper;
      _iCsvFileBuilder = fileBuilder;
    }

    public async Task<ExportCruisesVm> Handle(
      ExportCruisesQuery request,
      CancellationToken cancellationToken
    )
    {
      var vm = new ExportCruisesVm();

      var records = await _iApplicationDbContext.CruisePackages.Where(
          domainEntitiesCruisePackage => domainEntitiesCruisePackage.ListId == request.ListId
      ).ProjectTo<CruisePackageRecord>(
          _iMapper.ConfigurationProvider
      ).ToListAsync(
          cancellationToken
      );

      vm.Content = _iCsvFileBuilder.BuildCruisePackagesFile(records);
      vm.ContentType = "text/csv";
      vm.FileName = "CruisePackages.csv";

      return await Task.FromResult(vm);
    }
  }
}
