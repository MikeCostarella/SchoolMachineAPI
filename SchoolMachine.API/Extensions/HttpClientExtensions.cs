using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace SchoolMachine.API.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage PostObjectAsync(this HttpClient httpClient, string route, Object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(route, content).Result;
            return response;
        }
    }
}
