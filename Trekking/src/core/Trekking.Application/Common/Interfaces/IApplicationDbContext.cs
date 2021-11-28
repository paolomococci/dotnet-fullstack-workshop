using System.Threading;
using System.Threading.Tasks;
using Trekking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Trekking.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TrekList> TrekLists { get; set; }

        DbSet<TrekPackage> TrekPackages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
