using System.Threading.Tasks;
using Cruises.Application.CruiseLists.Commands.CreateCruiseList;
using Cruises.Application.CruiseLists.Commands.DeleteCruiseList;
using Cruises.Application.CruiseLists.Commands.UpdateCruiseList;
using Cruises.Application.CruiseLists.Queries.ExportCruises;
using Cruises.Application.CruiseLists.Queries.GetCruises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruises.WebApi.Controllers.v1
{
  public class CruiseListsController
    : ApiController
  {
    [HttpPost]
    public async Task<ActionResult<int>> Create(
        CreateCruiseListCommand createCruiseListCommand
    )
    {
      return await Mediator.Send(createCruiseListCommand);
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Read(int id)
    {
      var exportCruisesVm = await Mediator.Send(
        new ExportCruisesQuery
        {
          ListId = id
        }
      );

      return File(
        exportCruisesVm.Content,
        exportCruisesVm.ContentType,
        exportCruisesVm.FileName
      );
    }

    [HttpGet]
    public async Task<ActionResult<CruisesVm>> ReadAll()
    {
      return await Mediator.Send(
        new GetCruisesQuery()
      );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
      int id,
      UpdateCruiseListCommand updateCruiseListCommand
    )
    {
      if (id != updateCruiseListCommand.Id)
      {
        return BadRequest();
      }

      await Mediator.Send(updateCruiseListCommand);

      return StatusCode(StatusCodes.Status205ResetContent);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      await Mediator.Send(
          new DeleteCruiseListCommand
          {
            Id = id
          }
      );

      return NoContent();
    }
  }
}
