using Microsoft.AspNetCore.Mvc;
using InGazAPI.Models;
using InGazAPI.Data;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly YourDbContext _context;

        public UsersController(YourDbContext context)
        {
            _context = context;
        }

        // GET, POST, PUT, DELETE methods here...
    }
}
