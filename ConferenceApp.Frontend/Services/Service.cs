using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConferenceApp.Frontend.Services
{
    public class Service
    {
        public HttpClient _client;
        private const string BaseURL = "http://localhost:5000";
        private const string BaseAPIPrefix = "/api";

        public Service(HttpClient client)
        {
            _client = client;
        }
        private string URL(string entity, string action, string id) 
        {
            switch (action)
            {
                case "list":
                    return $"{BaseURL}{BaseAPIPrefix}/{entity}s";
                case "item":
                    return $"{BaseURL}{BaseAPIPrefix}/{entity}/{id}";
                case "create":
                    return $"{BaseURL}{BaseAPIPrefix}/{entity}";
                default:
                    return "";
            }
        }
        public async Task<IEnumerable<T>> GetList<T>(Type t)
        {
            var resp = await _client.GetAsync(URL(t.Name, "list", ""));
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ServiceError($"Status is {resp.StatusCode}");
            }
            return JsonConvert.DeserializeObject<IEnumerable<T>>(await resp.Content.ReadAsStringAsync());
        }
        public async Task<T> GetItem<T>(Type t, int id)
        {
            var resp = await _client.GetAsync($"{BaseURL}{BaseAPIPrefix}/{t.Name}/{id}");
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ServiceError($"Status is {resp.StatusCode}");
            }
            return JsonConvert.DeserializeObject<T>(await resp.Content.ReadAsStringAsync());
        }

        public async Task Create<T>(Type t, T item)
        {
            var serialized = JsonConvert.SerializeObject(item);
            await _client.PostAsync($"{BaseURL}{BaseAPIPrefix}{t.Name}", new StringContent(serialized));
        }
    }
}
