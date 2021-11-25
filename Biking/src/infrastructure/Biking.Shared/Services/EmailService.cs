using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Biking.Application.Common.Exceptions;
using Biking.Application.Common.Interfaces;
using Biking.Application.Dtos.Email;
using Biking.Domain.Settings;

namespace Biking.Shared.Services
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

                await smtpClient.SendAsync(mimeMessage);
                await smtpClient.DisconnectAsync(true);
            }
            catch (System.Exception systemException)
            {
                Logger.LogError(systemException.Message, systemException);
                throw new ApiException(systemException.Message);
            }
        }
    }
}
