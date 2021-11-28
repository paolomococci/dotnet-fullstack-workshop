using Trekking.Application.Dtos.User;
using Trekking.Domain.Entities;

namespace Trekking.Application.Common.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
    }
}
