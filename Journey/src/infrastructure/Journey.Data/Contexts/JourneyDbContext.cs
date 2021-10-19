using Journey.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Data.Contexts
{
    public class JourneyDbContext : DbContext
    {
        public JourneyDbContext(DbContextOptions<JourneyDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<JourneySelection> JourneySelections { get; set; }
        public DbSet<JourneyList> JourneyLists { get; set; }
    }
}
