using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace event_api.Models
{
    public class TicketmasterClient
    {

        public TicketmasterClient()
        {
        }

        public async Task<List<TicketMasterEvent>> queryTicketmasterEvents()
        {
            List<TicketMasterEvent> eventList = new List<TicketMasterEvent>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync("https://app.ticketmaster.com/discovery/v2/events?apikey=Nah4D2mJlI4fRTfwmPDd2cacDEmvPxZo&locale=*"))
                {
                    response.EnsureSuccessStatusCode();
                    var apiResponse = response.Content.ReadAsStringAsync();
                    TicketMasterResponse queryResponse = JsonConvert.DeserializeObject<TicketMasterResponse>(apiResponse.Result.ToString());

                    eventList = queryResponse._embedded.events;
                }
                return eventList;
            }
        }
    }
}