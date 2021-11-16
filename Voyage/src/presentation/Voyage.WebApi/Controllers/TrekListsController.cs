using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voyage.Application.TrekLists.Commands.CreateTrekList;
using Voyage.Application.TrekLists.Queries.GetTreks;

namespace Voyage.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<TreksVm>> Read()
        {
            return await Mediator.Send(new GetTreksQuery());
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
