using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace event_api.Models
{
    public class SeakGeekClient
    {

        public SeakGeekClient()
        {
        }

        public async Task<List<SeatGeekEvent>> querySeakGeekEvents()
        {
            List<SeatGeekEvent> eventList = new List<SeatGeekEvent>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync("https://api.seatgeek.com/2/events?venue.state=NY&client_id=MjUwNjYxNTZ8MTY0MDAyMzY4NS40NzAxNTU"))
                {
                    response.EnsureSuccessStatusCode();
                    var apiResponse = response.Content.ReadAsStringAsync();
                    SeatGeekResponse queryResponse = JsonConvert.DeserializeObject<SeatGeekResponse>(apiResponse.Result.ToString());

                    eventList = queryResponse.events;
                }
                return eventList;
            }
        }
    }
}
