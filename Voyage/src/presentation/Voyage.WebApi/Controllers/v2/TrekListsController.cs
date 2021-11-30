using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Voyage.Application.TrekLists.Commands.CreateTrekList;
using Voyage.Application.TrekLists.Commands.DeleteTrekList;
using Voyage.Application.TrekLists.Commands.UpdateTrekList;
using Voyage.Application.TrekLists.Queries.ExportTreks;
using Voyage.Application.TrekLists.Queries.GetTreks;

namespace Voyage.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TrekListsController : VoyageApiController
    {
        private readonly IMemoryCache _iMemoryCache;

        public TrekListsController(IMemoryCache iMemoryCache)
        {
            _iMemoryCache = iMemoryCache;
        }

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
            if (!_iMemoryCache.TryGetValue(
                null,
                out TreksVm treks
            ))
            {
                treks = await Mediator.Send(new GetTreksQuery());
                var cacheExpirationOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(6),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                };
                _iMemoryCache.Set(
                    null,
                    treks,
                    cacheExpirationOptions
                );
            }

            return treks;
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
