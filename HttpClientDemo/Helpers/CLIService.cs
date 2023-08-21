using HttpModel.Api.Model;

namespace HttpClientDemo.Helpers
{
    public class CLIService
    {
        private static int WelcomePage()
        {
            int temp;
            Console.WriteLine("Please, enter a number between 1 and 4");
            var input = Console.ReadLine();
            Int32.TryParse(input, out temp);
            return temp;
        }

        public static int Decision()
        {
            var input = WelcomePage();
            if (input < 1 || input>4)
            {
                input = Decision();
            }
            return input;
        }

        public static async Task Options(int decision)
        {
            switch (decision)
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
                    Console.WriteLine(result);
                    break;
                case 2:
                    int response;
                    await Console.Out.WriteLineAsync("Enter person ID");
                    var temp = Console.ReadLine();
                    var res = Int32.TryParse(temp, out response);
                    if (res)
                    {
                        var apiResponse = await DataDemo<PersonDto>.GetOneEntity("https://localhost:7213/api/Person/GetPersonById", response);
                        Console.WriteLine($"Name {apiResponse.Name}\nPhone Number {apiResponse.PhoneNumber}\nEmail {apiResponse.Email}");
                    }
                    WelcomePage();
                    break;
                case 3:
                    var apiRes = await DataDemo<List<PersonDto>>.HttpGet("https://localhost:7213/api/Person/GetPerons");
                    foreach ( PersonDto item in apiRes )
                    {
                        Console.WriteLine($"Name {item.Name}\nPhone Number {item.PhoneNumber}\nEmail {item.Email}");
                    };
                    break; 
                case 4:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}


