using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Application.Common.Interfaces;

namespace Voyage.Application.TrekLists.Queries.ExportTreks
{
    public class ExportTreksQueryHandler : IRequestHandler<ExportTreksQuery, ExportTreksVm>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;
        private readonly IMapper _iMapper;
        private readonly ICsvFileBuilder _iCsvFileBuilder;

        public ExportTreksQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            ICsvFileBuilder fileBuilder
        )
        {
            _iApplicationDbContext = context;
            _iMapper = mapper;
            _iCsvFileBuilder = fileBuilder;
        }

        public async Task<ExportTreksVm> Handle(
            ExportTreksQuery request,
            CancellationToken cancellationToken
        )
        {
            var vm = new ExportTreksVm();

            var records = await _iApplicationDbContext.TrekPackages.Where(
                domainEntitiesTrekPackage => domainEntitiesTrekPackage.ListId == request.ListId
            ).ProjectTo<TrekPackageRecord>(
                _iMapper.ConfigurationProvider
            ).ToListAsync(
                cancellationToken
            );

            vm.Content = _iCsvFileBuilder.BuildTrekPackagesFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = "TrekPackages.csv";

            return await Task.FromResult(vm);
        }
    }
}
