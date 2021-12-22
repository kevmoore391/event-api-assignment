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
                var ticketMasterURI = System.Configuration.ConfigurationManager.AppSettings.Get("TicketmasterURI");
                var ticketMasterToken = System.Configuration.ConfigurationManager.AppSettings.Get("TicketmasterToken");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync(ticketMasterURI + "/events?apikey=" + ticketMasterToken  + "&locale=*"))
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