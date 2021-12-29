using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager = System.Configuration.ConfigurationManager;
namespace EventApiAssignment.Models

{
    public class EventService
    {
        private readonly EventContext _context;
        public EventService()
        {
            var options = new DbContextOptionsBuilder<EventContext>().UseSqlServer(ConfigurationManager.AppSettings.Get("sqlServerConnection")).Options;
            _context = new EventContext(options);
        }

        public void retrieveTicketmasterEvents()
        {
            Console.WriteLine("starting Ticketmaster Retrieval");
            var ticketmasterClient = new TicketmasterClient();
            var ticketmasterData = ticketmasterClient.queryTicketmasterEvents();
            if (ticketmasterData != null)
            {
                ticketmasterData.Result.ForEach(t =>
                {
                    var currentEvent = ToEvent(t);
                    if (currentEvent != null)
                    {
                        saveEvent(currentEvent);
                    }
                });
                
            }
            _context.SaveChanges();
            Console.WriteLine("finished TicketMaster Retrieval");
        }

        public void retrieveSeatGeekEvents()
        {
            Console.WriteLine("starting Seat Geek Retrieval");
            var seatGeekClient = new SeakGeekClient();
            var seatGeekData= seatGeekClient.querySeakGeekEvents();
            if (seatGeekData != null)
            {
                seatGeekData.Result.ForEach(t =>
                {
                    var currentEvent = ToEvent(t);
                    if (currentEvent != null)
                    {
                        saveEvent(currentEvent);
                    }
                });

            }
            _context.SaveChanges();
            Console.WriteLine("Finished Seat Geek Retrieval");
        }

        private void saveEvent(Event eventToSave)
        {
            var existingEvent = _context.Events.Find(eventToSave.Id);
            if (existingEvent == null)
            {
                _context.Events.AddAsync(eventToSave);
            }
        }

        private Event? ToEvent(TicketMasterEvent ticketMasterEvent)
        {

            if (ticketMasterEvent == null) return null;

            return new Event
            {
                Id = ticketMasterEvent.id,
                EventName = ticketMasterEvent?.name,
                VenueName = ticketMasterEvent?._embedded?.venues?.FirstOrDefault()?.name,
                VenueCity = ticketMasterEvent?._embedded?.venues?.FirstOrDefault()?.city?.name,
                Type = ticketMasterEvent?.type,
                EventDescription = ticketMasterEvent?.info,
                PerformanceDate = ticketMasterEvent?.dates?.start?.dateTime
            };
        }

        private Event? ToEvent(SeatGeekEvent seatGeekEvent)
        {

            if (seatGeekEvent == null) return null;

            return new Event
            {
                Id = seatGeekEvent.id,
                EventName = seatGeekEvent.title,
                VenueName = seatGeekEvent?.venue?.name,
                VenueCity = seatGeekEvent?.venue?.city,
                Type = seatGeekEvent?.type,
                EventDescription = seatGeekEvent?.description,
                PerformanceDate = seatGeekEvent?.datetime_utc
            };
        }
    }
}
