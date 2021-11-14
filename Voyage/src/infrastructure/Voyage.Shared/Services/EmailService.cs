using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
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
                var mimeMessage = new MimeMessage
                {
                    Sender = MailboxAddress
                        .Parse(emailRequest.From ?? MailSettings.EmailFrom)
                };

                mimeMessage.To.Add(MailboxAddress.Parse(emailRequest.To));
                mimeMessage.Subject = emailRequest.Subject;

                var builder = new BodyBuilder
                {
                    HtmlBody = emailRequest.Body
                };

                mimeMessage.Body = builder.ToMessageBody();

                using var smtpClient = new SmtpClient();

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
