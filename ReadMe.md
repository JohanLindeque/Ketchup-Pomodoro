# 🍅 Ketchup Pomodoro
A lightweight Pomodoro timer that runs in your terminal, built with C# and Spectre.Console.


## Features
Quick start presets — jump straight into a 25m/5m or 50m/10m split from the menu
Custom intervals — pick any work and rest duration from a list
Goal tracking — set a focus goal displayed throughout the session
Live countdown — animated progress bar with time remaining updated every second
Session rounds — prompted to continue or quit after each work/rest cycle


---
## Installation
### Prerequisites

.NET 10 runtime/SDK or later

### Clone and run

```bash
git clone https://github.com/your-username/ketchup-pomodoro.git
cd ketchup-pomodoro
dotnet run
```

### Build a release binary
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

Replace win-x64 with linux-x64 or osx-x64 as needed.

---
## Usage
Run the app and follow the prompts:
```bash
dotnet run
```

At the main menu, choose a mode:
``` bash
Choose your Pomodoro:
> Quick Start: 25m/5m
  Quick Start: 50m/10m
  Custom Split
  EXIT
```
• Quick Start: 25m/5m — classic Pomodoro, no configuration needed
• Quick Start: 50m/10m — extended focus session, no configuration needed
• Custom Split — choose your own work and rest intervals from a list, then set your goal

For all modes you will be prompted for a goal before the timer starts (defaults to Get Stuff Done!).
Once started, the timer displays:
```
┌─ Goal ────────────┐
│ Get Stuff Done!   │
└───────────────────┘

Doing some work...
⠋ Time Left: 00:45  ████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░   18%

```
After each full work + rest cycle you will be prompted to continue or quit.

Built With

C# / .NET 10
Spectre.Console


License
MIT