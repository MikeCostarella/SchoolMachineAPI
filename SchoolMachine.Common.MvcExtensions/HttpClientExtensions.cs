using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace SchoolMachine.Common.MvcExtensions
{
    public static class HttpClientExtensions
    {
        public static Object GetObjectAsync<T>(this HttpClient httpClient, string route)
        {
            var response = httpClient.GetAsync(route).Result;
            response.EnsureSuccessStatusCode();
            var obj = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            return obj;
        }

        public static HttpResponseMessage PostObjectAsync(this HttpClient httpClient, string route, Object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(route, content).Result;
            return response;
        }

        public static HttpResponseMessage PutObjectAsync(this HttpClient httpClient, string route, Object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync(route, content).Result;
            return response;
        }
    }
}
