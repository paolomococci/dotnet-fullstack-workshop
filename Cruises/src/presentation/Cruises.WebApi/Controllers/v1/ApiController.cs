using Cruises.Identity.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Cruises.WebApi.Controllers.v1
{
  [Authorize]
  [ApiVersion("1.0")]
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  public abstract class ApiController
    : ControllerBase
  {
    private IMediator _iMediator;

    protected IMediator Mediator => _iMediator ??= HttpContext
        .RequestServices.GetService<IMediator>();
  }
}
