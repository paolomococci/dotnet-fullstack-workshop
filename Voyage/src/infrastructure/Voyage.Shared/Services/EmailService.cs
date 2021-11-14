using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Voyage.Application.Common.Exceptions;
using Voyage.Application.Common.Interfaces;
using Voyage.Application.Dtos.Email;
using Voyage.Domain.Settings;

namespace Voyage.Shared.Services
{
    public class EmailService : IEmailService
    {
        private MailSettings MailSettings { get; }
        private ILogger<EmailService> Logger { get; }

        public EmailService(
            IOptions<MailSettings> mailSettings,
            ILogger<EmailService> logger
        )
        {
            MailSettings = mailSettings.Value;
            Logger = logger;
        }

        public async Task SendAsync(EmailDto emailRequest)
        {
            try
            {
                // TODO
            }
            catch (System.Exception systemException)
            {
                Logger.LogError(systemException.Message, systemException);
                throw new ApiException(systemException.Message);
            }
        }
    }
}
