using Cruises.Application.Common.Interfaces;
using Cruises.Identity.Helpers;
using Cruises.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cruises.Identity
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureIdentity(
      this IServiceCollection iServiceCollection,
      IConfiguration iConfiguration
    )
    {
      iServiceCollection.Configure<AuthSettings>(
          iConfiguration.GetSection(nameof(AuthSettings))
      );

      iServiceCollection.AddScoped<IUserService, UserService>();

      return iServiceCollection;
    }
  }
}
