using Trekking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Trekking.Data.Contexts
{
    public class TrekkingDbContext : DbContext
    {
        public TrekkingDbContext(
            DbContextOptions<TrekkingDbContext> dbContextOptions
        ) : base(dbContextOptions)
        { }
        public DbSet<TrekList> TrekLists { get; set; }
        public DbSet<TrekPackage> TrekPackages { get; set; }
    }
}
