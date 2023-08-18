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
                input = WelcomePage();
            }
            return input;
        }
    }
}
