using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cruises.Data.Contexts
{
  public class ApplicationDbContext
    : DbContext, IApplicationDbContext
  {

    private readonly IDateTime _iDateTime;
    private IDbContextTransaction _iDbContextTransaction;

    public ApplicationDbContext(
      DbContextOptions<ApplicationDbContext> options
    ) : base(options)
    { }

    public DbSet<CruiseList> CruiseLists
    {
      get;
      set;
    }
    public DbSet<CruisePackage> CruisePackages
    {
      get;
      set;
    }

    public ApplicationDbContext(
      DbContextOptions<ApplicationDbContext> options,
      IDateTime dateTime
    ) : base(options)
    {
      _iDateTime = dateTime;
    }

    public override Task<int> SaveChangesAsync(
      CancellationToken cancellationToken = new CancellationToken()
    )
    {
      return base.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
      if (_iDbContextTransaction != null)
      {
        return;
      }

      _iDbContextTransaction = await base.Database
          .BeginTransactionAsync(IsolationLevel.ReadCommitted)
          .ConfigureAwait(false);
    }

    public async Task CommitTransactionAsync()
    {
      try
      {
        await SaveChangesAsync().ConfigureAwait(false);
        _iDbContextTransaction?.Commit();
      }
      catch
      {
        RollbackTransaction();
        throw;
      }
      finally
      {
        if (_iDbContextTransaction != null)
        {
          _iDbContextTransaction.Dispose();
          _iDbContextTransaction = null;
        }
      }
    }

    private void RollbackTransaction()
    {
      try
      {
        _iDbContextTransaction?.Rollback();
      }
      finally
      {
        if (_iDbContextTransaction != null)
        {
          _iDbContextTransaction.Dispose();
          _iDbContextTransaction = null;
        }
      }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfigurationsFromAssembly(
        Assembly.GetExecutingAssembly()
      );
      base.OnModelCreating(builder);
    }
  }
}
