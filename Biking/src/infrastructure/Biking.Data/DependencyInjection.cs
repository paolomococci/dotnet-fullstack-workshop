using Biking.Application.Common.Interfaces;
using Biking.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biking.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(
            this IServiceCollection services
        )
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite("Data Source=BikingTrekDatabase.sqlite3")
            );

            services.AddScoped<IApplicationDbContext>(
                provider => (IApplicationDbContext)provider.GetService<ApplicationDbContext>()
            );

            return services;
        }
    }
}
