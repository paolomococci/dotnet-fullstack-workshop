using System.Threading;
using System.Threading.Tasks;
using Biking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biking.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TrekList> TrekLists { get; set; }

        DbSet<TrekPackage> TrekPackages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
