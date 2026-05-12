using Ketchup_Pomodoro.Services;
using Spectre.Console;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var quitApp = false;
        var pomodoro = new PomodoroTimerService();
        var goal = string.Empty;

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
                    goal = AnsiConsole.Ask<string>(
                        "What's your [Gold1]Goal[/]?",
                        "Get Stuff Done!"
                    );
                    pomodoro.CreatePomodoro(25, 5, goal).Wait();
                    break;
                case "Quick Start: 50m/10m":
                    Console.Clear();
                    goal = AnsiConsole.Ask<string>(
                        "What's your [Gold1]Goal[/]?",
                        "Get Stuff Done!"
                    );
                    pomodoro.CreatePomodoro(25, 5, goal).Wait();
                    break;

                case "Custom Split":
                    Console.Clear();
                    goal = AnsiConsole.Ask<string>(
                        "What's your [Gold1]Goal[/]?",
                        "Get Stuff Done!"
                    );

                    var workInterval = AnsiConsole.Prompt(
                        new SelectionPrompt<int>()
                            .Title("[DeepSkyBlue1]Choose your Work Interval(minutes):[/]")
                            .AddChoices(1, 2, 5, 10, 15, 25, 30, 40, 50)
                    );

                    var restInterval = AnsiConsole.Prompt(
                        new SelectionPrompt<int>()
                            .Title("[MediumPurple]Choose your Rest Interval(minutes):[/]")
                            .AddChoices(1, 2, 5, 10, 15, 25, 30, 40, 50)
                    );

                    pomodoro.CreatePomodoro(workInterval, restInterval, goal).Wait();
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
