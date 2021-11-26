using System.Threading.Tasks;
using Biking.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Biking.Identity.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthSettings _authSettings;

        public JwtMiddleware(
            RequestDelegate next,
            IOptions<AuthSettings> appSettings
        )
        {

        }

        public async Task Invoke(
            HttpContext context,
            IUserService userService
        )
        {

        }

        private void AttachUserToContext(
            HttpContext context,
            IUserService userService,
            string token
        )
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
