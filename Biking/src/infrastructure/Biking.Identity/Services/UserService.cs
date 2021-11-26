using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Biking.Application.Common.Interfaces;
using Biking.Application.Dtos.User;
using Biking.Domain.Entities;
using Biking.Identity.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Biking.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly AuthSettings _authSettings;

        public UserService(
            IOptions<AuthSettings> appSettings
        ) => _authSettings = appSettings.Value;

        private readonly List<User> _users = new List<User> {
            new User {
                Id = 1,
                FirstName = "somename",
                LastName = "somesurname",
                Username = "someusername",
                Password = "3xa4a1e0f50me9as5w0r6"
            }
        };
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(
                tempRefUser => tempRefUser.Username == model.Username && tempRefUser.Password == model.Password
            );

            if (user == null)
            {
                return null;
            }
            var tokenString = GenerateJwtToken(user);

            return new AuthenticateResponse(
                user,
                tokenString
            );
        }

        private string GenerateJwtToken(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] {
                        new Claim(
                            "id",
                            user.Id.ToString()
                        )
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public User GetById(int id) => _users.FirstOrDefault(
            tempRefUser => tempRefUser.Id == id
        );
    }
}
