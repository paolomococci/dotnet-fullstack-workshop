using Biking.Application.Dtos.User;
using Biking.Domain.Entities;

namespace Biking.Application.Common.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
    }
}
