using Biking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biking.Data.Contexts
{
    public class BikingDbContext : DbContext
    {
        public BikingDbContext(
            DbContextOptions<BikingDbContext> dbContextOptions
        ) : base(dbContextOptions)
        { }
        public DbSet<TrekList> TrekLists { get; set; }
        public DbSet<TrekPackage> TrekPackages { get; set; }
    }
}
