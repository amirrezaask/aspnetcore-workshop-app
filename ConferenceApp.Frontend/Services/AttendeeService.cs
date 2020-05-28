using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

using System.Threading.Tasks;

namespace ConferenceApp.Frontend.Services
{
    public class AttendeeService
    {
        public HttpClient _client;
        private const string BaseURL = "http://localhost:5000";
        private const string BaseAPIPrefix = "/api";
        private const string BaseNamespace = "/Attendees";
        public AttendeeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Domain.Attendee>> GetAttendees() 
        {
            var resp = await _client.GetAsync($"{BaseURL}{BaseAPIPrefix}{BaseNamespace}");
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ServiceError($"Status is {resp.StatusCode}");
            }
            return JsonConvert.DeserializeObject<IEnumerable<Domain.Attendee>>(await resp.Content.ReadAsStringAsync());
        }
    }
}
