using Microsoft.EntityFrameworkCore;
using Voyage.Application.Common.Interfaces;
using Voyage.Domain.Entities;

namespace Voyage.Data.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<TrekList> TrekLists
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }
        public DbSet<TrekPackage> TrekPackages
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }
    }
}
