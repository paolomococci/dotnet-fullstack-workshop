using Trekking.Application.Common.Interfaces;
using Trekking.Application.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Trekking.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _iUserService;
        public UsersController(
            IUserService userService
        ) => _iUserService = userService;

        [HttpPost("auth")]
        public IActionResult Authenticate(
            [FromBody] AuthenticateRequest model
        )
        {
            var response = _iUserService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(
                    new
                    {
                        message = "access denied"
                    }
                );
            }

            return Ok(response);
        }
    }
}
