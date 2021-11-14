using System.Threading.Tasks;
using Voyage.Application.Common.Interfaces;
using Voyage.Application.Dtos.Email;

namespace Voyage.Shared.Services
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(EmailDto emailRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
