using System;
using System.ComponentModel.DataAnnotations;
using Ketchup_Pomodoro.Models;

namespace Ketchup_Pomodoro.Services;

public class PomodoroTimerService
{
    private Session _session;

    public async Task CreatePomodoro(int work, int rest)
    {
        _session = new Session("Do work", work, rest, Session.SessionType.work);

        var timeLeft = _session.WorkDuration;

        while (timeLeft > TimeSpan.Zero)
        {
            Console.Clear();
            Console.WriteLine(_session.WorkCaption);
            Console.Write($"\rTime left: {timeLeft.ToString(@"mm\:ss")}   ");
            await Task.Delay(1000);

            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
        }

        _session.Active = Session.SessionType.rest;
        timeLeft = _session.RestDuration;

        while (timeLeft > TimeSpan.Zero)
        {
            Console.Clear();

            Console.WriteLine(_session.RestCaption);
            Console.Write($"\rTime left: {timeLeft.ToString(@"mm\:ss")}   ");
            await Task.Delay(1000);

            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
        }
    }

    private static void DrawSessionMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine("Completed!");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Do you want to continue?");
        Console.WriteLine("c. Continue");
        Console.WriteLine("q. quit");
        Console.WriteLine("----------------------------");
        Console.ResetColor();
    }
}
