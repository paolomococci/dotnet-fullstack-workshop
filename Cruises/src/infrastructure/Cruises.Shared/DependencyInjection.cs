using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cruises.Application.Common.Interfaces;
using Cruises.Domain.Settings;
using Cruises.Shared.Files;
using Cruises.Shared.Services;

namespace Cruises.Shared
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
