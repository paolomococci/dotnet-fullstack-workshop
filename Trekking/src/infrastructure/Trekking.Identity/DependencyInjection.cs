using Trekking.Application.Common.Interfaces;
using Trekking.Identity.Helpers;
using Trekking.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trekking.Identity
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
