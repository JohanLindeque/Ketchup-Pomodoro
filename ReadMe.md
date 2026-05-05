# Pomodoro timer cli

## Idea
I am building a Pomodoro cli tool to help me focus and get work done and finish tasks quicker.
The main idea is to be able to create custom pomodoro splits, or use a quick start (default 25 min focus 5min break) that will run in terminal with a progress bar in order to visually see your progress. 

## Basic flow
* Menu with options:
 [] Quick Start: run default pomodoro split (default 25 min focus 5min break) for 1 session (a session is a focus + break).
  - After session complete prompt: Continue or quit
  - quit to main menu and continue will run for another session
 [] Add custom pomodoro : able to create custom split and name it
  - custom splits will show in main menu along with default options
  
 [] q or ctrl + c to quit app.
 
## Additional features
- progress bar with count down timer.
- random colour progress bars.
- track a goal for session
- pause/resume/quit session
- track tasks to complete
- track amount of sessions completed
- cool animation/ screen when session complete
- add/remove/modify custom Pomodoro splits

----
## Questions 
1. how does pomodoro work?
2. how can i store and persist custom pomodoro splits?
3. how can i run the app using its name, for example like you call 'cat' or 'curl' to run them?

 
