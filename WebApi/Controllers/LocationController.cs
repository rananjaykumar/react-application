using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationContext _locationContext;
        public LocationController(LocationContext locationContext)
        {
            _locationContext = locationContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            if(_locationContext == null)    
                return NotFound();

            return Ok(new List<Location>());
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Location>> GetLocationByName(string name)
        { 
        if(_locationContext == null)
            {
                return NotFound();
            }
        var location = await _locationContext.Locations.FindAsync(name);
            if (location == null)
            {
                return NotFound();
            }
            return location;

        }
    }
}
