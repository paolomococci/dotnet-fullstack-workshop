using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cruises.Identity.Helpers
{
  public class JwtMiddleware
  {
    private readonly RequestDelegate _requestDelegate;
    private readonly AuthSettings _authSettings;

    public JwtMiddleware(
      RequestDelegate requestDelegate,
      IOptions<AuthSettings> iOptionsAuthSettings
    )
    {
      _requestDelegate = requestDelegate;
      _authSettings = iOptionsAuthSettings.Value;
    }

    public async Task Invoke(
      HttpContext httpContext,
      IUserService iUserService
    )
    {
      var token = httpContext.Request.Headers["Authorization"]
          .FirstOrDefault()?.Split(" ").Last();
      if (token != null)
      {
        AttachUserToContext(httpContext, iUserService, token);
      }
      await _requestDelegate(httpContext);
    }

    private void AttachUserToContext(
      HttpContext httpContext,
      IUserService iUserService,
      string token
    )
    {
      try
      {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);
        jwtSecurityTokenHandler.ValidateToken(
            token,
            new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(key),
              ValidateIssuer = false,
              ValidateAudience = false,
              ClockSkew = TimeSpan.Zero
            },
            out var validatedToken
        );
        var jwtSecurityToken = (JwtSecurityToken)validatedToken;
        var userId = int.Parse(
            jwtSecurityToken.Claims.First(
                claim => claim.Type == "id"
            ).Value
        );

        httpContext.Items["User"] = iUserService.GetById(userId);
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}
