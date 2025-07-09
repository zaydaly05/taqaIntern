using Microsoft.AspNetCore.Mvc;
using InGazAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        // Assuming a static list for demonstration purposes
        private static List<Reading> _readings = new List<Reading>();

        // GET: api/readings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reading>>> GetReadings()
        {
            // Simulating asynchronous behavior
            return await Task.FromResult(_readings);
        }

        // GET: api/readings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reading>> GetReading(int id)
        {
            var reading = await Task.FromResult(_readings.FirstOrDefault(r => r.Id == id));
            if (reading == null)
                return NotFound();

            return reading;
        }

        // POST: api/readings
        [HttpPost]
        public async Task<ActionResult<Reading>> CreateReading(Reading reading)
        {
            _readings.Add(reading);
            return CreatedAtAction(nameof(GetReading), new { id = reading.Id }, reading);
        }

        // PUT: api/readings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReading(int id, Reading reading)
        {
            if (id != reading.Id)
                return BadRequest();

            var existingReading = _readings.FirstOrDefault(r => r.Id == id);
            if (existingReading == null)
                return NotFound();

            // Update the existing reading
            existingReading.Value = reading.Value; // Assuming 'Value' is a property of Reading
            existingReading.Unit = reading.Unit; // Assuming 'Unit' is a property of Reading

            return NoContent();
        }

        // DELETE: api/readings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReading(int id)
        {
            var reading = await Task.FromResult(_readings.FirstOrDefault(r => r.Id == id));
            if (reading == null)
                return NotFound();

            _readings.Remove(reading);
            return NoContent();
        }
    }
}
