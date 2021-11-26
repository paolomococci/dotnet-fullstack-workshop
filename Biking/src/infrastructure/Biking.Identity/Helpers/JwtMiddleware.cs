using Microsoft.AspNetCore.Http;

namespace Biking.Identity.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthSettings _authSettings;
    }
}
