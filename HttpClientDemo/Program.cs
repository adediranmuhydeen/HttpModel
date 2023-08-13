// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using HttpModel.Api.Model;

//var uri = "https://mocki.io/v1/d33691f7-1eb5-45aa-9642-8d538f6c5ebd";
//var client = new HttpClient();

//Console.WriteLine(await client.GetStringAsync(uri));

//var result = DataDemo<List<PersonDto>>.HttpGet("https://localhost:7213/api/Person/GetPerons");
//Console.WriteLine(result);
var person = new PersonDto { Email = "adebayoawwaldele@gmail.com.com", Name = "Abdulsalam Adebayo", PhoneNumber = "080657828987" };
var resultPost = await DataDemo<PersonDto>.HttpPostAsJson("https://localhost:7213/api/Person/AddPerson", person);
var result = await DataDemo<PersonDto>.HttpPostAsync("https://localhost:7213/api/Person/AddPerson", person);

Console.WriteLine(result);
Console.WriteLine(resultPost);