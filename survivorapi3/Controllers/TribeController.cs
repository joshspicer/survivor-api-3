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
    public class TribeController : ControllerBase
    {
        private readonly SurvivorContext _context;

        public TribeController(SurvivorContext context)
        {
            _context = context;

            if (_context.TribeItems.Count() == 0)
            {

                var azure = new Tribe
                {
                    Name = "Azure",
                    Color = "blue",
                    players = new List<Player>(),
                };
                var rose = new Tribe
                {
                    Name = "Rose",
                    Color = "pink",
                    players = new List<Player>(),
                };


                // Create our two empty tribes if collection is empty,
                _context.TribeItems.Add(azure);
                _context.TribeItems.Add(rose);

                _context.SaveChanges();
            }
        }

        // GET: api/Tribe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tribe>>> GetTribeItems()
        {
            return await _context.TribeItems.ToListAsync();
        }

        // GET: api/Tribe/{INDEX}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tribe>> GetTodoItem(long id)
        {
            var tItem = await _context.TribeItems.FindAsync(id);

            if (tItem == null)
            {
                return NotFound();
            }

            return tItem;
        }

        // POST: api/Tribe
        [HttpPost]
        public async Task<ActionResult<Tribe>> PostTodoItem(Tribe item)
        {
            _context.TribeItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTribeItems), new { id = item.Id }, item);
        }

        // Put a player on a given tribe.
        [HttpPut("{id}")]
        public async Task<ActionResult<Tribe>> PutPlayerOnTribe(long id)//, [FromBody] string playerID)
        {

            long  tribeID = 1;
            var tribe = await _context.TribeItems.FindAsync(tribeID);
            //var player = await _context.PlayerItems.FindAsync(long.Parse(playerID));

            long playerID = 1;
            Player player = await _context.PlayerItems.FindAsync(playerID);


            // If either tribe or player is null
            if (tribe == null || player == null)
            {
                return NotFound();
            }

            // Place the player in the tribe's list of players
            tribe.players.Add(player);
            //_context.SaveChanges();

            return tribe;
        }





    } //end class


}
