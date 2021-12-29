/*using EventApiAssignment.Controllers;
using Microsoft.EntityFrameworkCore;
using EventApiAssignment.Models;
using Xunit;
using Assert = Xunit.Assert;
using System;

namespace EventApiAssignment.Tests
{

    public class EventControllerTest
    {
        private readonly EventContext _context;
        private readonly EventController _controller;

        public EventControllerTest()
        {
            var options = new DbContextOptionsBuilder<EventContext>().UseInMemoryDatabase("EventList").Options;
            _context = new EventContext(options);
            _controller = new EventController(_context);
        }

        [Fact]
        public void GetEvents_ShouldReturnAllEvents()
        {
            var testEvent = createEvent("1");
            _context.AddAsync(testEvent);
            _context.SaveChanges();
            
            var response = _controller.GetEvents();
            var returnedEvent = response.Find(current => current.Id == testEvent.Id);

            Assert.NotEmpty(response);
            Assert.Equal(returnedEvent, testEvent);
            _context.Events.Remove(testEvent);
            _context.SaveChanges();
        }

        [Fact]
        public void GetEvent_ShouldReturnSpecificEvent()
        {
            var testEvent = createEvent("2");
            _context.Events.AddAsync(testEvent);
            _context.SaveChanges();
            
            var response = _controller.GetEvent(testEvent.Id);

            Assert.NotNull(response);
            Assert.Equal(response.Result.Value.Id, testEvent.Id);
            _context.Events.Remove(testEvent);
            _context.SaveChanges();
        }

        [Fact]
        public void PutEvent_ShouldUpdateAndReturnSpecificEvent()
        {
            var testEvent = createEvent("3");
            var newEvent = createEvent(testEvent.Id, "New Test Event");
            _context.Events.AddAsync(testEvent);
            _context.SaveChanges();

            var response = _controller.PutEvent(newEvent.Id, newEvent);

            Assert.NotNull(response);
            var updatedEvent = _context.Events.Find(newEvent.Id);
            Assert.Equal(updatedEvent.Id, newEvent.Id);
            Assert.Equal(updatedEvent.EventName, newEvent.EventName);
            _context.Events.Remove(updatedEvent);
            _context.SaveChanges();
        }

        [Fact]
        public void PostEventItem_ShouldSaveAndReturnSpecificEvent()
        {
            var testEvent = createEvent("4");

            var response = _controller.PostEventItem(testEvent);

            Assert.NotNull(response);
            var savedEvent = _context.Events.Find(testEvent.Id);
            Assert.Equal(savedEvent.Id, testEvent.Id);
            _context.Events.Remove(testEvent);
            _context.SaveChanges();
        }

        [Fact]
        public void DeleteEventItem_ShouldRemoveEvent()
        {
            var testEvent = createEvent("5");
            _context.Events.AddAsync(testEvent);
            _context.SaveChanges();

            var response = _controller.DeleteEventItem(testEvent.Id);

            Assert.NotNull(response);
            var deletedEvent = _context.Events.Find(testEvent.Id);
            Assert.Null(deletedEvent);
        }

        private Event createEvent(
            string? Id = "testId213",
            string? EventName = "Test Event",
            string? VenueName = "Croke Park",
            string? VenueCity = "Dublin",
            string? Type = "Sport Event",
            string? EventDescription = "Test Event"
        )
        {
            return new Event
            {
                Id = Id,
                EventName = EventName,
                VenueName = VenueName,
                VenueCity = VenueCity,
                Type = Type,
                EventDescription = EventDescription,
                PerformanceDate = DateTime.Now
            };
        }
    }
}
*/