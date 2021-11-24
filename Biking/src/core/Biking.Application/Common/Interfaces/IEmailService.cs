using System.Threading.Tasks;
using Biking.Application.Dtos.Email;

namespace Biking.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}
