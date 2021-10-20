using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Journey.Data.Contexts;
using Journey.Domain.Entities;

namespace Journey.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JourneySelectionController : ControllerBase
    {
        private readonly JourneyDbContext _journeyDbContext;

        public JourneySelectionController(JourneyDbContext journeyDbContext)
        {
            _journeyDbContext = journeyDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] JourneySelection journeySelection
        )
        {
            try
            {
                await _journeyDbContext.JourneySelections.AddAsync(journeySelection);
                await _journeyDbContext.SaveChangesAsync();
                return Created("", journeySelection);
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
                var journeySelection = await _journeyDbContext
                    .JourneySelections.SingleOrDefaultAsync(
                        temp => temp.Id == id
                    );

                if (journeySelection == null)
                {
                    return NotFound();
                }

                return Ok(journeySelection);
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
                return Ok(_journeyDbContext.JourneySelections);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] JourneySelection journeySelection
        )
        {
            try
            {
                _journeyDbContext.Update(journeySelection);
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
                var journeySelection = await _journeyDbContext
                    .JourneySelections.SingleOrDefaultAsync(
                        temp => temp.Id == id
                    );

                if (journeySelection == null)
                {
                    return NotFound();
                }

                _journeyDbContext.JourneySelections.Remove(journeySelection);
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
