using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Voyage.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrekPackagesController : ApiController
    {
        [HttpPost]
        public int Create()
        {
            // TODO
            return StatusCodes.Status501NotImplemented;
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
