using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survivorapi3.Models;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio-mac


namespace survivorapi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly SurvivorContext _context;

        public PlayerController(SurvivorContext context)
        {
            _context = context;

            if (_context.PlayerItems.Count() == 0)
            {

                var josh = new Player
                {
                    Name = "Josh",
                    Hometown = "Whitman, MA",
                    Major = "Computer Science",
                    Year = "4th Year"
                };

                // Create a new Player if collection is empty,
                // which means you can't delete all TodoItems.
                _context.PlayerItems.Add(josh);
                _context.SaveChanges();
            }
        }

        // GET: api/PLAYER
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerItems()
        {
            return await _context.PlayerItems.ToListAsync();
        }

        // GET: api/PLAYER/{INDEX}
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerItem(long id)
        {
            var todoItem = await _context.PlayerItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/PLAYER
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayerItem(Player item)
        {
            _context.PlayerItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayerItems), new { id = item.Id }, item);
        }

        // PUT: api/PLAYER/{INDEX}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerItem(long id, Player item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }




    } //end class


}
