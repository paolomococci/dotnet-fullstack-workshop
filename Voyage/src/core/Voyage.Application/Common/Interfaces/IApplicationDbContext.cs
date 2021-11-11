using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Domain.Entities;

namespace Voyage.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TrekList> TrekLists { get; set; }

        DbSet<TrekPackage> TrekPackages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
