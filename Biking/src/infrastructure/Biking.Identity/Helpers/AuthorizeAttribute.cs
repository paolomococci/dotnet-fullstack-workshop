using System;
using Biking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Biking.Identity.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(
            AuthorizationFilterContext authorizationFilterContext
        )
        {
            var user = (User)authorizationFilterContext.HttpContext.Items["User"];
            if (user == null)
            {
                authorizationFilterContext.Result = new JsonResult(
                    new { message = "Unauthorized" }
                )
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
