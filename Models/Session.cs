using System;
using System.Security.Cryptography.X509Certificates;

namespace Ketchup_Pomodoro.Models;

public class Session
{
    public string Goal { get; set; } = String.Empty;
    public TimeSpan WorkDuration { get; set; } = TimeSpan.FromMinutes(25);
    public TimeSpan RestDuration { get; set; } = TimeSpan.FromMinutes(5);
    public SessionType Active { get; set; } = SessionType.work;
    public int Tally { get; set; } = 0;
    public string WorkCaption = "Doing some work...";
    public string RestCaption = "Resting...";

    public enum SessionType
    {
        none,
        work,
        rest,
    }

    public Session(string goal, int workDuration, int restDuration, SessionType active)
    {
        Goal = goal;
        WorkDuration = TimeSpan.FromMinutes(workDuration);
        RestDuration = TimeSpan.FromMinutes(restDuration);
        Active = active;
    }
}
