using System.Threading.Tasks;
using Cruises.Application.CruisePackages.Commands.CreateCruisePackage;
using Cruises.Application.CruisePackages.Commands.DeleteCruisePackage;
using Cruises.Application.CruisePackages.Commands.UpdateCruisePackage;
using Cruises.Application.CruisePackages.Commands.UpdateCruisePackageDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruises.WebApi.Controllers.v1
{
  public class CruisePackagesController
    : ApiController
  {
    [HttpPost]
    public async Task<ActionResult<int>> Create(
      CreateCruisePackageCommand createCruisePackageCommand
    )
    {
      return await Mediator.Send(createCruisePackageCommand);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
      int id,
      UpdateCruisePackageCommand updateCruisePackageCommand
    )
    {
      if (id != updateCruisePackageCommand.Id)
      {
        return BadRequest();
      }

      await Mediator.Send(updateCruisePackageCommand);

      return StatusCode(StatusCodes.Status205ResetContent);
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(
      int id,
      UpdateCruisePackageDetailCommand updateCruisePackageDetailCommand
    )
    {
      if (id != updateCruisePackageDetailCommand.Id)
      {
        return StatusCode(StatusCodes.Status205ResetContent);
      }

      await Mediator.Send(updateCruisePackageDetailCommand);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      await Mediator.Send(
        new DeleteCruisePackageCommand
        {
          Id = id
        }
      );

      return NoContent();
    }
  }
}
