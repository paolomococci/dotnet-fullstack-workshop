using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voyage.Application.TrekPackages.Commands.CreateTrekPackage;

namespace Voyage.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrekPackagesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(
            CreateTrekPackageCommand createTrekPackageCommand
        )
        {
            return await Mediator.Send(createTrekPackageCommand);
        }

        [HttpGet("{id}")]
        public int Read()
        {
            // TODO
            return StatusCodes.Status501NotImplemented;
        }

        [HttpGet]
        public int ReadAll()
        {
            // TODO
            return StatusCodes.Status501NotImplemented;
        }

        [HttpPut("{id}")]
        public int Update()
        {
            // TODO
            return StatusCodes.Status501NotImplemented;
        }

        [HttpDelete("{id}")]
        public int Delete()
        {
            // TODO
            return StatusCodes.Status501NotImplemented;
        }
    }
}
