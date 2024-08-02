using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly Lazy<HttpClient> _httpClient =
       new(() =>
       {
           var httpClient = new HttpClient();
           httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           return httpClient;
       },
           LazyThreadSafetyMode.ExecutionAndPublication);

        public async Task<TResult?> GetAsync<TResult>(string uri)
        {
            HttpClient httpClient = GetOrCreateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);

            await RequestProvider.HandleResponse(response).ConfigureAwait(false);

            return await response.Content.ReadFromJsonAsync<TResult>();
        }

        public async Task<TResult?> PostAsync<TResult>(string uri, TResult data)
        {
            HttpClient httpClient = GetOrCreateHttpClient();

     
            var content = new StringContent(JsonSerializer.Serialize(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);

            await RequestProvider.HandleResponse(response).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>();

        }

        private HttpClient GetOrCreateHttpClient()
        {
            return _httpClient.Value;
    
        }

        private static async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

              
                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }
    }
}
