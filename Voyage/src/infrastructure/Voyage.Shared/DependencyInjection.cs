using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Voyage.Application.Common.Interfaces;
using Voyage.Domain.Settings;
using Voyage.Shared.Files;
using Voyage.Shared.Services;

namespace Voyage.Shared
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
