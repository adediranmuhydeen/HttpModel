using HttpClientDemo.Helpers;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HttpClientDemo
{
#nullable disable
    public  class DataDemo<T> where T : class
    {

        public static async Task<T> HttpGet(string uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseStr = await response.Content.ReadAsStringAsync();
                    var JsonResponse = JsonSerializer.Deserialize<T>(responseStr, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    //ApiErrorHandler<T>.GetApiErrorResponse(responseStr);
                    return JsonResponse;

                }
                return null;
            }
        }

        public static async Task<string> HttpPostAsJson(string uri, T data) 
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(uri, data);
               // ApiErrorHandler<T>.GetApiErrorResponse( await response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> HttpPostAsync(string uri, T data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var neResponse = JsonSerializer.Serialize(data);
                    var stringContent = new StringContent(neResponse, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return null;
        }

        public static async Task<T> GetOneEntity(string uri, int id)
        {
            try
            {

                using(var client = new HttpClient())
                {
                    using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
                    {
                        requestMessage.Headers.Add("id", $"{id}");
                        var request = await client.SendAsync(requestMessage);
                        var apiResponse = JsonSerializer.Deserialize<T>(await request.Content.ReadAsStringAsync(), new JsonSerializerOptions(){PropertyNameCaseInsensitive=true });
                        return apiResponse;
                    }
                }
               
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return null;
        }
    }
}
