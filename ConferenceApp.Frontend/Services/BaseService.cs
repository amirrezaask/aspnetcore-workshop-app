using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConferenceApp.Frontend.Services
{
    public class BaseService
    {
        public HttpClient _client;
        private const string BaseURL = "http://localhost:5000";
        private const string BaseAPIPrefix = "/api";

        public BaseService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<T>> GetList<T>(Type t)
        {
            var resp = await _client.GetAsync($"{BaseURL}{BaseAPIPrefix}{t.GetType().Name}");
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ServiceError($"Status is {resp.StatusCode}");
            }
            return JsonConvert.DeserializeObject<IEnumerable<T>>(await resp.Content.ReadAsStringAsync());
        }
        public async Task<T> GetItem<T>(Type t, int id)
        {
            var resp = await _client.GetAsync($"{BaseURL}{BaseAPIPrefix}{t.GetType().Name}/{id}");
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ServiceError($"Status is {resp.StatusCode}");
            }
            return JsonConvert.DeserializeObject<T>(await resp.Content.ReadAsStringAsync());
        }
    }
}
