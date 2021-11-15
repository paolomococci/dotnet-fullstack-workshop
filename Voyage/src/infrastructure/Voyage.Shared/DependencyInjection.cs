using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Voyage.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureShared(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            // TODO

            return services;
        }
    }
}
