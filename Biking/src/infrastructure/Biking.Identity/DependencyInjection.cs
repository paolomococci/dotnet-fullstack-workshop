using Biking.Application.Common.Interfaces;
using Biking.Identity.Helpers;
using Biking.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biking.Identity
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
