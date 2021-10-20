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
    [Route("api/[controller")]
    public class JourneySelectionController : ControllerBase
    {
        private readonly JourneyDbContext _journeyDbContext;

        public JourneySelectionController(JourneyDbContext journeyDbContext)
        {
            _journeyDbContext = journeyDbContext;
        }

        [HttpGet]
        public IActionResult GetActionResult()
        {
            return Ok(_journeyDbContext.JourneySelections);
        }
    }
}
