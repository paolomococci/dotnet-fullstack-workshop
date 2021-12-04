using Cruises.Application.Common.Interfaces;
using Cruises.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cruises.Data
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureData(
        this IServiceCollection services
    )
    {
      services.AddDbContext<ApplicationDbContext>(
          options => options.UseSqlite(
            "Data Source=CruisesDatabase.sqlite3"
          )
      );

      services.AddScoped<IApplicationDbContext>(
          provider => (IApplicationDbContext)provider
            .GetService<ApplicationDbContext>()
      );

      return services;
    }
  }
}
