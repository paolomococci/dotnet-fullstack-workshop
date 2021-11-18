using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Voyage.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _iMediator;

        protected IMediator Mediator => _iMediator ??= HttpContext
            .RequestServices.GetService<IMediator>();
    }
}
