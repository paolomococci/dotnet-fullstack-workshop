using System.Threading.Tasks;
using Biking.Application.TrekLists.Commands;
using Biking.Application.TrekLists.Commands.DeleteTrekList;
using Biking.Application.TrekLists.Commands.UpdateTrekList;
using Biking.Application.TrekLists.Queries.ExportTreks;
using Biking.Application.TrekLists.Queries.GetTreks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biking.WebApi.Controllers.v1
{
    public class TrekListsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(
            CreateTrekListCommand createTrekListCommand
        )
        {
            return await Mediator.Send(createTrekListCommand);
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Read(int id)
        {
            var exportTreksVm = await Mediator.Send(
                new ExportTreksQuery
                {
                    ListId = id
                }
            );

            return File(
                exportTreksVm.Content,
                exportTreksVm.ContentType,
                exportTreksVm.FileName
            );
        }

        [HttpGet]
        public async Task<ActionResult<TreksVm>> ReadAll()
        {
            return await Mediator.Send(new GetTreksQuery());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            int id,
            UpdateTrekListCommand updateTrekListCommand
        )
        {
            if (id != updateTrekListCommand.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(updateTrekListCommand);

            return StatusCode(StatusCodes.Status205ResetContent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(
                new DeleteTrekListCommand
                {
                    Id = id
                }
            );

            return NoContent();
        }
    }
}
