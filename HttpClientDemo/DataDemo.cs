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
                return await response.Content.ReadAsStringAsync();
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
