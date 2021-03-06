using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Biking.Application.Common.Interfaces;
using Biking.Domain.Settings;
using Biking.Shared.Files;
using Biking.Shared.Services;

namespace Biking.Shared
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
