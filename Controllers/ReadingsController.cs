using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InGazAPI.Data;
using InGazAPI.Models;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        private readonly DataContext _context;

        public ReadingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/readings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reading>>> GetReadings()
        {
            return await _context.Readings.Include(r => r.Unit).ToListAsync();
        }

        // GET: api/readings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reading>> GetReading(int id)
        {
            var reading = await _context.Readings.Include(r => r.Unit).FirstOrDefaultAsync(r => r.Id == id);
            if (reading == null)
                return NotFound();

            return reading;
        }

        // POST: api/readings
        [HttpPost]
        public async Task<ActionResult<Reading>> CreateReading(Reading reading)
        {
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReading), new { id = reading.Id }, reading);
        }

        // PUT: api/readings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReading(int id, Reading reading)
        {
            if (id != reading.Id)
                return BadRequest();

            _context.Entry(reading).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/readings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReading(int id)
        {
            var reading = await _context.Readings.FindAsync(id);
            if (reading == null)
                return NotFound();

            _context.Readings.Remove(reading);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
