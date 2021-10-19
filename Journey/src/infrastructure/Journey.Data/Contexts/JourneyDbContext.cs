using Microsoft.EntityFrameworkCore;

namespace Journey.Data.Contexts
{
    public class JourneyDbContext : DbContext
    {
        public JourneyDbContext(DbContextOptions<JourneyDbContext> dbContextOptions) : base(dbContextOptions) { }


    }
}
