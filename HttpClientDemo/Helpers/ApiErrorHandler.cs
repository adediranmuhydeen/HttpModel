using System.Text.Json;

namespace HttpClientDemo.Helpers
{
    public class ApiErrorHandler<T> where T : class
    {
        public static void GetApiErrorResponse(string responseBody)
        {
            try
            {
                var result = new Dictionary<string, List<string>>();

                var element = JsonSerializer.Deserialize<JsonElement>(responseBody);
                var JsonError = element.GetProperty("error");

                foreach (var item in JsonError.EnumerateObject())
                {
                    var errorList = new List<string>();
                    var key = item.Name;
                    foreach (var x in item.Value.EnumerateObject())
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
            catch(JsonException ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
           
        }
    } 
    



    public class ApiErrorHandler2<T> where T : class
    {
        public static Dictionary<string, List<string>> GetApiErrorResponse(string responseBody)
        {
            var result = new Dictionary<string, List<string>>();

            try
            {
                var element = JsonSerializer.Deserialize<JsonElement>(responseBody);
                var jsonError = element.GetProperty("error");

                foreach (var item in jsonError.EnumerateObject())
                {
                    var errorList = new List<string>();
                    var key = item.Name;

                    foreach (var x in item.Value.EnumerateArray()) // Assuming error items are an array
                    {
                        // Properly deserialize JSON value if needed
                        var errorObject = JsonSerializer.Deserialize<T>(x.GetRawText());
                        var errorString = errorObject.ToString(); // Adjust this based on your error object structure
                        errorList.Add(errorString);
                    }

                    result.Add(key, errorList);
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return result;
        }
    }

}
