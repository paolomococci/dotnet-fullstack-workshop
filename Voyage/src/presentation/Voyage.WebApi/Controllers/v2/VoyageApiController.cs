using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Voyage.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class VoyageApiController : ControllerBase
    {
        private IMediator _iMediator;

        protected IMediator Mediator => _iMediator ??= HttpContext
            .RequestServices.GetService<IMediator>();
    }
}
