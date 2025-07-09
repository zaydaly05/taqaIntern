using Microsoft.AspNetCore.Mvc;
using InGazAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationsController : ControllerBase
    {
        // Assuming a static list for demonstration purposes
        private static List<Station> _stations = new List<Station>();

        // GET: api/stations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations()
        {
            // Simulating asynchronous behavior
            return await Task.FromResult(_stations);
        }

        // GET: api/stations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Station>> GetStation(int id)
        {
            var station = await Task.FromResult(_stations.FirstOrDefault(s => s.Id == id));
            if (station == null)
                return NotFound();

            return station;
        }

        // POST: api/stations
        [HttpPost]
        public async Task<ActionResult<Station>> CreateStation(Station station)
        {
            // Assuming you want to set the ModifiedBy property
            // ModifiedBy = user.name; // This line needs context on how to get the user name
            _stations.Add(station);
            return CreatedAtAction(nameof(GetStation), new { id = station.Id }, station);
        }

        // PUT: api/stations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(int id, Station station)
        {
            if (id != station.Id)
                return BadRequest();

            var existingStation = _stations.FirstOrDefault(s => s.Id == id);
            if (existingStation == null)
                return NotFound();

            // Update the existing station properties
            existingStation.Name = station.Name; // Assuming 'Name' is a property of Station
            existingStation.Area = station.Area; // Assuming 'Area' is a property of Station

            return NoContent();
        }

        // DELETE: api/stations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(int id)
        {
            var station = await Task.FromResult(_stations.FirstOrDefault(s => s.Id == id));
            if (station == null)
                return NotFound();

            _stations.Remove(station);
            return NoContent();
        }
    }
}
