using System.Threading.Tasks;
using Trekking.Application.Dtos.Email;

namespace Trekking.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}
