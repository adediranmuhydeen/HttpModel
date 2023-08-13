using System.Text.Json;

namespace HttpClientDemo.Helpers
{
    public class ApiErrorHandler
    {
        public static Dictionary<string, List<string>> GetApiErrorResponse(string responseBody)
        {
            var result = new Dictionary<string, List<string>>();

            var element = JsonSerializer.Deserialize<JsonElement>(responseBody);
            var JsonError = element.GetProperty("error");

            foreach (var item in JsonError.EnumerateObject())
            {
                var errorList = new List<string>();
                var key = item.Name;
                foreach(var x in item.Value.EnumerateObject())
                {
                    errorList.Add(x.ToString());
                }
                result.Add(key, errorList);
            }

            return result;
        }
    }
}
