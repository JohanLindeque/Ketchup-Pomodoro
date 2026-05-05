using Ketchup_Pomodoro.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var quitApp = false;
        var pomodoro = new PomodoroTimerService();

        while (!quitApp)
        {
            DrawMainMenu();

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    // Console.WriteLine("Ready to start 25/5 split?");
                    // Thread.Sleep(2000);
                    pomodoro.CreatePomodoro(25,5).Wait();
                    break;

                case "2":
                    Console.Clear();
                    // Console.WriteLine("Ready to start 50/10 split?");
                    // Thread.Sleep(5000);
                    pomodoro.CreatePomodoro(50,10).Wait();
                    break;

                case "q":
                    Console.Clear();
                    Console.WriteLine("Bye bye");
                    quitApp = true;
                    break;

                default:
                    break;
            }
        }
    }

    private static void DrawMainMenu()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Welcome to Ketchup-Pomodoro");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Choose your Pomodoro");
        Console.WriteLine("1. 25/5");
        Console.WriteLine("2. 50/10");
        Console.WriteLine("q. quit");
        Console.WriteLine("----------------------------");
        Console.ResetColor();
    }
}
