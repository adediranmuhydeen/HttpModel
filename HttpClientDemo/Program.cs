﻿using HttpClientDemo;
using HttpClientDemo.Helpers;
using HttpModel.Api.Model;
using Serilog;

//var uri = "https://mocki.io/v1/d33691f7-1eb5-45aa-9642-8d538f6c5ebd";
//var client = new HttpClient();

//Console.WriteLine(await client.GetStringAsync(uri));

//var result = DataDemo<List<PersonDto>>.HttpGet("https://localhost:7213/api/Person/GetPerons");
//Console.WriteLine(result);
var person = new PersonDto { Email = "adebayoawwaldele@gmail", Name = "Abdulsalam Adebayo", PhoneNumber = "080657828987" };
var rson = new PersonDto { Email = "adebayoawwaldele@gmail", Name = "Awwal Adebayo", PhoneNumber = "080757828987" };
 await DataDemo<PersonDto>.HttpPostAsJson("https://localhost:7213/api/Person/AddPerson", person);
await DataDemo<PersonDto>.HttpPostAsync("https://localhost:7213/api/Person/AddPerson", rson);

Console.WriteLine("<-----------------------------------------WELCOME--------------------------------------->\n" + "To add a person, press 1\n" + "To Get a person, press 2\n" + "To Get all persons press 3\n" +
   "To \'Exit\' this application, press 4");
Console.WriteLine("Please, enter a number between 1 and 4");
await CLIService.Options();

Console.ReadLine();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("C:\\Users\\adediranma\\source\\repos\\HttpClientDemo\\HttpClientDemo\\ErrorLogger.log", rollingInterval:RollingInterval.Day).CreateLogger();