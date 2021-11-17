using Microsoft.EntityFrameworkCore;
using Voyage.Domain.Entities;

namespace Voyage.Data.Contexts
{
    public class VoyageDbContext : DbContext
    {
        public VoyageDbContext(
            DbContextOptions<VoyageDbContext> dbContextOptions
        ) : base(dbContextOptions)
        { }
        public DbSet<TrekList> TrekLists { get; set; }
        public DbSet<TrekPackage> TrekPackages { get; set; }
    }
}
