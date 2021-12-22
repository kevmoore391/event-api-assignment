namespace event_api.Models
{
    public class TicketMasterEvent
    {
        public string id { get; set; }
        public string? name { get; set; }
        public string? type{ get; set; }
        public TicketMasterEmbeddedVenues? _embedded { get; set; }
        public string? info { get; set; }
        public TicketMasterEventDate? dates { get; set; }
    }
}
