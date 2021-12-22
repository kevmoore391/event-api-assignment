using FluentScheduler;
using event_api.Models;
namespace event_api.Services
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
