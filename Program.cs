using Ketchup_Pomodoro.Services;
using Spectre.Console;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var quitApp = false;
        var pomodoro = new PomodoroTimerService();

        while (!quitApp)
        {
            HandleDrawArt.DrawLogo();

            var userInput = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose your Pomodoro:")
                    .AddChoices(
                        "Quick Start: 25m/5m",
                        "Quick Start: 50m/10m",
                        "Custom Split",
                        "EXIT"
                    )
            );

            switch (userInput)
            {
                case "Quick Start: 25m/5m":
                    Console.Clear();
                    pomodoro.CreatePomodoro(25, 5).Wait();
                    break;
                case "Quick Start: 50m/10m":
                    Console.Clear();
                    pomodoro.CreatePomodoro(25, 5).Wait();
                    break;

                case "Custom Split":
                    Console.Clear();
                    pomodoro.CreatePomodoro(1, 1).Wait();
                    break;

                case "EXIT":
                    Console.Clear();
                    Console.WriteLine("Bye bye");
                    quitApp = true;
                    break;

                default:
                    break;
            }
        }
    }
}
