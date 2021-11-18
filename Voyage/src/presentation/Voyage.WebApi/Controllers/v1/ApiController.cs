using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Voyage.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private IMediator _iMediator;

        protected IMediator Mediator => _iMediator ??= HttpContext
            .RequestServices.GetService<IMediator>();
    }
}
