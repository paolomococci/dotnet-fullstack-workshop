using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Voyage.Application.Common.Interfaces;
using Voyage.Data.Contexts;

namespace Voyage.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(
            this IServiceCollection services
        )
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite("Data Source=VoyageTrekDatabase.sqlite3")
            );

            services.AddScoped<IApplicationDbContext>(
                provider => (IApplicationDbContext)provider.GetService<ApplicationDbContext>()
            );

            return services;
        }
    }
}
