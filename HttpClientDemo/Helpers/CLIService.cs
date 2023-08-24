using HttpModel.Api.Model;

namespace HttpClientDemo.Helpers
{
    public class CLIService
    {

        public static async Task Options()
        {
            Start:
            int tem;
            Console.WriteLine("Please, enter a number between 1 and 4");
            var input = Console.ReadLine();
            var boo = Int32.TryParse(input, out tem);
            if(!boo)
            {
                Console.WriteLine("Input is not numerical\n");
                goto Start;
            }
            if (tem < 1 || tem > 4)
            {
                await Console.Out.WriteLineAsync("The value entered is not valid\n");
                goto Start;
            }

            switch (tem)
            {
                case 1:
                    await Console.Out.WriteLineAsync("Enter the person name");
                    var name = Console.ReadLine();
                    await Console.Out.WriteLineAsync("Enter person phone number");
                    var phoneNumber = Console.ReadLine();
                    await Console.Out.WriteLineAsync("Enter person email address");
                    var email= Console.ReadLine();
                    var person = new PersonDto
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        Email = email
                    };
                    var result =await DataDemo<PersonDto>.HttpPostAsJson("https://localhost:7213/api/Person/AddPerson", person);
                    Console.WriteLine(result + "\n");
                    goto Start;
                case 2:
                    int response;
                    await Console.Out.WriteLineAsync("Enter person ID");
                    var temp = Console.ReadLine();
                    var res = Int32.TryParse(temp, out response);
                    if (res)
                    {
                        var apiResponse = await DataDemo<PersonDto>.GetOneEntity("https://localhost:7213/api/Person/GetPersonById", response);
                        if(apiResponse != null)
                        {
                            Console.WriteLine($"Name {apiResponse.Name}\nPhone Number {apiResponse.PhoneNumber}\nEmail {apiResponse.Email}\n");
                        }
                        else
                        {
                            Console.WriteLine($"User with Id {response} was not found");
                        }
                       
                    }
                    else
                    {
                        await Console.Out.WriteLineAsync("Invalid input");
                    }
                    goto Start;
                case 3:
                    var apiRes = await DataDemo<List<PersonDto>>.HttpGet("https://localhost:7213/api/Person/GetPerons");
                    foreach ( PersonDto item in apiRes )
                    {
                        Console.WriteLine($"Name {item.Name}\nPhone Number {item.PhoneNumber}\nEmail {item.Email}\n");
                    };
                    goto Start;
                case 4:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}


