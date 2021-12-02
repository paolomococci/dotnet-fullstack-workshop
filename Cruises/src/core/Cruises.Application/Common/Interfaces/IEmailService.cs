using System.Threading.Tasks;
using Cruises.Application.Dtos.Email;

namespace Cruises.Application.Common.Interfaces
{
  public interface IEmailService
  {
    Task SendAsync(EmailDto emailRequest);
  }
}
