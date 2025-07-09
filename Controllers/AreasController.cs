using Microsoft.AspNetCore.Mvc;
using InGazAPI.Models;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly DataContext _context;

        public AreasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAreas()
        {
            var areas = _context.Areas.Include(a => a.Stations).ToList();
            return Ok(areas);
        }

        [HttpPost]
        public IActionResult CreateArea([FromBody] Area area)
        {
            _context.Areas.Add(area);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllAreas), new { id = area.Id }, area);
        }
    }
}
