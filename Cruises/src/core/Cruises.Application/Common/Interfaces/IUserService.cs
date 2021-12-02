using Cruises.Application.Dtos.User;
using Cruises.Domain.Entities;

namespace Cruises.Application.Common.Interfaces
{
  public interface IUserService
  {
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    User GetById(int id);
  }
}
