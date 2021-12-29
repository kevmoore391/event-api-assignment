namespace EventApiAssignment.Models
{
    public class SeatGeekEvent
    {
        public string id { get; set; }
        public string? title { get; set; }
        public string? type { get; set; }
        public string? description { get; set; }
        public DateTime? datetime_utc { get; set; }
        public SeatGeekVenue? venue { get; set; }
    }
}
