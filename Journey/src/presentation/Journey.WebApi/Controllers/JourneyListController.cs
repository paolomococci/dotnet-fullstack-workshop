using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Create([FromBody] JourneyList journeyList)
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

        [HttpGet]
        public IActionResult ReadAll()
        {
            return Ok(_journeyDbContext.JourneyLists);
        }
    }
}
