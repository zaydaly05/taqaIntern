using Microsoft.AspNetCore.Mvc;
using InGazAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        // Assuming a static list for demonstration purposes
        private static List<Area> _areas = new List<Area>();

        [HttpGet]
        public IActionResult GetAllAreas()
        {
            // Return the static list of areas
            return Ok(_areas);
        }

        [HttpPost]
        public IActionResult CreateArea([FromBody] Area area)
        {
            // Add the new area to the static list
            _areas.Add(area);
            return CreatedAtAction(nameof(GetAllAreas), new { id = area.AreaId }, area);
        }
    }
}
