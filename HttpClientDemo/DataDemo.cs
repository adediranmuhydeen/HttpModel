using HttpClientDemo.Helpers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HttpClientDemo
{
#nullable disable
    public static class DataDemo<T> where T : class
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
                    await Console.Out.WriteLineAsync(ApiErrorHandler<T>.GetApiErrorResponse(JsonResponse);
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
                ApiErrorHandler<T>.GetApiErrorResponse( await response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> HttpPostAsync(string uri, T data)
        {
            using(var client = new HttpClient())
            {
                var neResponse = JsonSerializer.Serialize(data);
                var stringContent = new StringContent(neResponse, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, stringContent);
                var result = await response.Content.ReadAsStringAsync();
                ApiErrorHandler<T>.GetApiErrorResponse(result);
                return result;
            }
        }
    }

    public class Res
    {
        public List<Data> Data{ get; set; }
    }

    public class Data
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publication_Date { get; set; }
    }
}
