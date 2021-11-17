using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Voyage.Application.Common.Interfaces;
using Voyage.Domain.Entities;

namespace Voyage.Data.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        private readonly IDateTime _dateTime;
        private IDbContextTransaction _currentTransaction;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        { }

        public DbSet<TrekList> TrekLists
        {
            get;
            set;
        }
        public DbSet<TrekPackage> TrekPackages
        {
            get;
            set;
        }
    }
}
