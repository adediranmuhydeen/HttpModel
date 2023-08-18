using System.Text.Json;

namespace HttpClientDemo.Helpers
{
    public class ApiErrorHandler<T> where T : class
    {
        public static void GetApiErrorResponse(string responseBody)
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
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                foreach (var value in item.Value)
                {
                    Console.WriteLine(value);
                }
            }
        }

       
    }

    
}
