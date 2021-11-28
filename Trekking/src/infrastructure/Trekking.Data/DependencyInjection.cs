using Trekking.Application.Common.Interfaces;
using Trekking.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Trekking.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(
            this IServiceCollection services
        )
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite("Data Source=TrekkingTrekDatabase.sqlite3")
            );

            services.AddScoped<IApplicationDbContext>(
                provider => (IApplicationDbContext)provider.GetService<ApplicationDbContext>()
            );

            return services;
        }
    }
}
