
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventApiAssignment.Models;
using System.Text.RegularExpressions;

namespace EventApiAssignment.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        
        public EventController(EventContext context)
        {
            _context = context;            
        }

        // GET: /Event
        [HttpGet]
        public List<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        // GET: Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(string id)
        {
            if (!validateId(id))
            {
                return ValidationProblem("Id must be alphanumeric");
            }

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
            if (!validateId(id))
            {
                return ValidationProblem("Id must be alphanumeric");
            }

            if (id != eventToUpdate.Id)
            {
                return BadRequest();
            }
            var foundEvent = await _context.Events.FindAsync(id);
            foundEvent.EventName = eventToUpdate.EventName;
            foundEvent.VenueName = eventToUpdate.VenueName;
            foundEvent.VenueCity = eventToUpdate.VenueCity;
            foundEvent.EventDescription = eventToUpdate.EventDescription;
            foundEvent.Type = eventToUpdate.Type;
            foundEvent.PerformanceDate = eventToUpdate.PerformanceDate;

            _context.Update(foundEvent);

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
        public async Task<ActionResult<Event>> PostEventItem(Event eventToSave)
        {
            _context.Events.Add(eventToSave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = eventToSave.Id }, eventToSave);
        }

        // DELETE: Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventItem(string id)
        {
            if (!validateId(id))
            {
                return ValidationProblem("Id must be alphanumeric");
            }

            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool validateId(string input)
        {
            Regex rgx = new Regex("^[a-zA-Z0-9]*$");
            return rgx.IsMatch(input);
        }

        private bool EventExists(string id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
