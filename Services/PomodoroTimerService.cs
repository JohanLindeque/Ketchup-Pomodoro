using System;
using Ketchup_Pomodoro.Models;
using Spectre.Console;

namespace Ketchup_Pomodoro.Services;

public class PomodoroTimerService
{
    private Session _session;

    public async Task CreatePomodoro(
        int workInterval,
        int restInterval,
        string goal = "Get Stuff Done!"
    )
    {
        _session = new Session(goal, workInterval, restInterval, Session.SessionType.work);

        var continueSession = true;

        while (continueSession)
        {
            await RunTimer(_session.WorkDuration, _session.WorkCaption, goal, Color.DeepSkyBlue1);

            _session.Active = Session.SessionType.rest;

            await RunTimer(_session.RestDuration, _session.RestCaption, goal, Color.MediumPurple);

            continueSession = ContinueSession();
        }
    }

    private async Task RunTimer(TimeSpan duration, string caption, string goal, Color color)
    {
        Console.Clear();

        AnsiConsole.Write(
            new Panel($"[yellow]{goal}[/]").Header(" Goal ").Border(BoxBorder.Rounded)
        );

        AnsiConsole.MarkupLine($"\n[{color}]{caption}[/]");

        var timeLeft = duration;

        await AnsiConsole
            .Progress()
            .AutoClear(false)
            .HideCompleted(false)
            .Columns(
                new SpinnerColumn(Spinner.Known.Dots),
                new TaskDescriptionColumn(),
                new PercentageColumn()
            )
            .StartAsync(async ctx =>
            {
                var task = ctx.AddTask(
                    $"[{color}]Time Left: {timeLeft:mm\\:ss}[/]",
                    maxValue: duration.TotalSeconds
                );

                while (!ctx.IsFinished)
                {
                    timeLeft -= TimeSpan.FromSeconds(1);
                    var pct = 1.0 - (timeLeft.TotalSeconds / duration.TotalSeconds);
                    var filled = (int)(pct * 40);
                    var bar = $"[{Color.Green}]{"".PadLeft(filled, '█').PadRight(40, '░')}[/]";
                    task.Description = $"[{color}]Time Left: {timeLeft:mm\\:ss}[/] {bar}";
                    task.Increment(1);
                    await Task.Delay(1000);
                }
            });
    }

    private static bool ContinueSession()
    {
        Console.Clear();

        AnsiConsole.MarkupLine(
            @"[MediumTurquoise]
            ░█▀▀░█▀█░█▄█░█▀█░█░░░█▀▀░▀█▀░█▀▀░█▀▄░█
            ░█░░░█░█░█░█░█▀▀░█░░░█▀▀░░█░░█▀▀░█░█░▀
            ░▀▀▀░▀▀▀░▀░▀░▀░░░▀▀▀░▀▀▀░░▀░░▀▀▀░▀▀░░▀
        [/]"
        );

        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[Plum3]Do you want to continue?[/]")
                .AddChoices("Continue", "Quit")
        );

        return userInput == "Continue";
    }
}
