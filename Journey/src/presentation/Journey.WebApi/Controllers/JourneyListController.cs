using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Journey.Data.Contexts;
using Journey.Domain.Entities;

namespace Journey.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JourneyListController : ControllerBase
    {
        private readonly JourneyDbContext _journeyDbContext;

        public JourneyListController(JourneyDbContext journeyDbContext)
        {
            _journeyDbContext = journeyDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] JourneyList journeyList
        )
        {
            try
            {
                await _journeyDbContext.JourneyLists.AddAsync(journeyList);
                await _journeyDbContext.SaveChangesAsync();
                return Created("", journeyList);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] int id)
        {
            try
            {
                var journeyList = await _journeyDbContext
                    .JourneyLists.SingleOrDefaultAsync(
                        temp => temp.Id == id
                    );

                if (journeyList == null)
                {
                    return NotFound();
                }

                return Ok(journeyList);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(_journeyDbContext.JourneyLists);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] JourneyList journeyList
        )
        {
            try
            {
                _journeyDbContext.Update(journeyList);
                await _journeyDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var journeyList = await _journeyDbContext
                    .JourneyLists.SingleOrDefaultAsync(
                        temp => temp.Id == id
                    );

                if (journeyList == null)
                {
                    return NotFound();
                }

                _journeyDbContext.JourneyLists.Remove(journeyList);
                await _journeyDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
