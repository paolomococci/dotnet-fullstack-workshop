using Biking.Application.Common.Interfaces;
using Biking.Application.Dtos.User;
using Biking.Domain.Entities;

namespace Biking.Identity.Services
{
    public class UserService : IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

