using Cruises.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Data.Contexts
{
  public class CruisesDbContext
    : DbContext
  {
    public CruisesDbContext(
      DbContextOptions<CruisesDbContext> dbContextOptions
    ) : base(dbContextOptions)
    { }
    public DbSet<CruiseList> CruiseLists { get; set; }
    public DbSet<CruisePackage> CruisePackages { get; set; }
  }
}
