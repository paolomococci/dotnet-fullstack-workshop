using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trekking.Application.Common.Interfaces;
using Trekking.Domain.Settings;
using Trekking.Shared.Files;
using Trekking.Shared.Services;

namespace Trekking.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureShared(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            return services;
        }
    }
}
