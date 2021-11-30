using System.Threading.Tasks;
using Trekking.Application.TrekPackages.Commands.CreateTrekPackage;
using Trekking.Application.TrekPackages.Commands.DeleteTrekPackage;
using Trekking.Application.TrekPackages.Commands.UpdateTrekPackage;
using Trekking.Application.TrekPackages.Commands.UpdateTrekPackageDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System;
using Trekking.WebApi.Controllers.v1;
using Trekking.Application.Dtos.Trek;

namespace Trekking.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TrekPackagesController : ApiController
    {
        private readonly IMemoryCache _iMemoryCache;

        public TrekPackagesController(IMemoryCache iMemoryCache)
        {
            _iMemoryCache = iMemoryCache;
        }

        [HttpGet("{trekPackageName}")]
        public ActionResult<List<TrekPackageDto>> ReadByName(string trekPackageName)
        {
            var trekPackageNameCacheKey = trekPackageName.ToLower();

            if (!_iMemoryCache.TryGetValue(
                trekPackageNameCacheKey,
                out List<TrekPackageDto> trekPackages
            ))
            {
                // TODO
            }

            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(
            CreateTrekPackageCommand createTrekPackageCommand
        )
        {
            return await Mediator.Send(createTrekPackageCommand);
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

            return StatusCode(StatusCodes.Status205ResetContent);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(
            int id,
            UpdateTrekPackageDetailCommand updateTrekPackageDetailCommand
        )
        {
            if (id != updateTrekPackageDetailCommand.Id)
            {
                return StatusCode(StatusCodes.Status205ResetContent);
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
