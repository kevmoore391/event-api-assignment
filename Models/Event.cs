namespace event_api.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string? EventName{ get; set; }
        public string? VenueName { get; set; }
        public string? VenueCity { get; set; }
        public string? Type { get; set; }
        public string? EventDescription { get; set; }
        public DateTime? PerformanceDate { get; set; }
    }
}
