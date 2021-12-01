using Trekking.Identity.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Trekking.WebApi.Controllers.v2
{
    [Authorize]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _iMediator;

        protected IMediator Mediator => _iMediator ??= HttpContext
            .RequestServices.GetService<IMediator>();
    }
}
