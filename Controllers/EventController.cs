
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using event_api.Models;

namespace event_api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly EventService _eventService;
        
        public EventController(EventContext context)
        {
            _context = context;            
        }

        // GET: /Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(long id)
        {
            var foundEvent = await _context.Events.FindAsync(id);

            if (foundEvent == null)
            {
                return NotFound();
            }

            return foundEvent;
        }

        // PUT: Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(string id, Event eventToUpdate)
        {
            if (id != eventToUpdate.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostTodoItem(Event eventToSave)
        {
            _context.Events.Add(eventToSave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = eventToSave.Id }, eventToSave);
        }

        // DELETE: Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(string id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
