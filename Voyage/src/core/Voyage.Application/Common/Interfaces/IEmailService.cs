using System.Threading.Tasks;
using Voyage.Application.Dtos.Email;

namespace Voyage.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}
