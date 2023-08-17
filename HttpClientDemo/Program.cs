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

Console.WriteLine("<------------------------------------------Welcome----------------------------------------------->\n" +
    "To Add employee press 1\n" +
    "To get an employee detail press 2\n" +
    "To get all employee press 3\n" +
    "To exit press 4");
var imput  = Console.ReadLine();

int expected;

try
{
    if(Int32.TryParse(imput, out expected))
    {
        if (expected < 1 || expected > 4)
        {
            Console.WriteLine("You must enter a numerical value between 1 to 4");
        }
        switch (expected)
        {
            case 1:
                Console.WriteLine("Enter the person name");
                var name = Console.ReadLine();
                Console.WriteLine("Enter the person phone number");
                var phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter the person email address");
                var email = Console.ReadLine();
                var personDto = new PersonDto { Email = email, Name = name, PhoneNumber = phoneNumber };
                Console.WriteLine(DataDemo<PersonDto>.HttpPost("https://localhost:7213/api/Person/AddPerson", personDto)); ;
                break;
        }
    }
    else
    {
        Console.WriteLine("Please, enter a numerical value between 1 to 4");
    }
}
catch(Exception ex)
{
    Console.WriteLine($"An error occour: {ex.Message}");
}
Console.ReadLine();