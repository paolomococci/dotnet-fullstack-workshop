using Microsoft.AspNetCore.Mvc;

namespace Voyage.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrekPackagesController : ApiController
    {
        [HttpPost]
        public void Create()
        {
            // TODO
        }
        [HttpGet("{id}")]
        public void Read()
        {
            // TODO
        }
        [HttpGet]
        public void ReadAll()
        {
            // TODO
        }
        [HttpPut("{id}")]
        public void Update()
        {
            // TODO
        }
        [HttpDelete("{id}")]
        public void Delete()
        {
            // TODO
        }
    }
}
