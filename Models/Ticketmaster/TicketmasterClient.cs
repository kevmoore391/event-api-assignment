using System.Net.Http.Headers;
using Newtonsoft.Json;
using ConfigurationManager = System.Configuration.ConfigurationManager;
namespace EventApiAssignment.Models
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
                var ticketMasterURI = ConfigurationManager.AppSettings.Get("TicketmasterURI");
                var ticketMasterToken = ConfigurationManager.AppSettings.Get("TicketmasterToken");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync(ticketMasterURI + "/events?stateCode=NY&apikey=" + ticketMasterToken  + "&locale=*"))
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