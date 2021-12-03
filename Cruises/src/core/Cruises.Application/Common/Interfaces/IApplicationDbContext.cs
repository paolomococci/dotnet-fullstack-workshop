using System.Threading;
using System.Threading.Tasks;
using Cruises.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.Common.Interfaces
{
  public interface IApplicationDbContext
  {
    DbSet<CruiseList> CruiseLists { get; set; }

    DbSet<CruisePackage> CruisePackages { get; set; }

    Task<int> SaveChangesAsync(
      CancellationToken cancellationToken
    );
  }
}
