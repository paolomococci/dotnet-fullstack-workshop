using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voyage.Application.TrekPackages.Commands.CreateTrekPackage;
using Voyage.Application.TrekPackages.Commands.DeleteTrekPackage;
using Voyage.Application.TrekPackages.Commands.UpdateTrekPackage;
using Voyage.Application.TrekPackages.Commands.UpdateTrekPackageDetail;

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
        public ActionResult Read()
        {
            return StatusCode(501);
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            int id,
            UpdateTrekPackageCommand updateTrekPackageCommand
        )
        {
            if (id != updateTrekPackageCommand.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(updateTrekPackageCommand);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(
            int id,
            UpdateTrekPackageDetailCommand updateTrekPackageDetailCommand
        )
        {
            if (id != updateTrekPackageDetailCommand.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(updateTrekPackageDetailCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(
                new DeleteTrekPackageCommand
                {
                    Id = id
                }
            );

            return NoContent();
        }
    }
}
