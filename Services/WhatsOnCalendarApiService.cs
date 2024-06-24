using Bills.Models;
using System.Text.Json;

namespace Bills.Services
{
    public class WhatsOnCalendarApiService
    {
        public string apiURl = "https://whatson-api.parliament.uk";

        public async Task<List<Session>> GetSessionsBills()
        {
            string url = string.Format("{0}/calendar/sessions/list.json", apiURl);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            List<Session> sessions = JsonSerializer.Deserialize<List<Session>>(responseObjects);

            return sessions.OrderByDescending(x => x.SessionId).ToList();
        }

    }
}
