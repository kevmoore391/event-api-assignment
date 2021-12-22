using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace event_api.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;
    }
}