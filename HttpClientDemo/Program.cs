// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using HttpModel.Api.Model;

//var uri = "https://mocki.io/v1/d33691f7-1eb5-45aa-9642-8d538f6c5ebd";
//var client = new HttpClient();

//Console.WriteLine(await client.GetStringAsync(uri));

//var result = DataDemo<List<PersonDto>>.HttpGet("https://localhost:7213/api/Person/GetPerons");
//Console.WriteLine(result);
var person = new Person { Email = "adediran@adebayo.com", Name = "Adediran Muhydeen", PhoneNumber = "08061695754" };
var resultPost = await DataDemo<Person>.HttpPost("https://localhost:7213/api/Person/AddPerson", person);

Console.WriteLine(resultPost);