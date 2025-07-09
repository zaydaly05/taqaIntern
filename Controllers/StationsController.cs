using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InGazAPI.Data;
using InGazAPI.Models;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly DataContext _context;

        public StationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/stations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations()
        {
            return await _context.Stations.Include(s => s.Area).ToListAsync();
        }

        // GET: api/stations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Station>> GetStation(int id)
        {
            var station = await _context.Stations.Include(s => s.Area).FirstOrDefaultAsync(s => s.Id == id);
            if (station == null)
                return NotFound();

            return station;
        }

        // POST: api/stations
        [HttpPost]
        public async Task<ActionResult<Station>> CreateStation(Station station)
        {
            ModifiedBy = user.name;
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStation), new { id = station.Id }, station);
        }

        // PUT: api/stations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(int id, Station station)
        {
            if (id != station.Id)
                return BadRequest();

            _context.Entry(station).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/stations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(int id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station == null)
                return NotFound();

            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
