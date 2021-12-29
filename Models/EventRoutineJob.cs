using FluentScheduler;
using EventApiAssignment.Models;
namespace EventApiAssignment.Services
{
    public class EventRoutineJob : IJob
    {
        public void Execute()
        {
            var eventService = new EventService();
            eventService.retrieveTicketmasterEvents();
            eventService.retrieveSeatGeekEvents();
        }
    }
}
