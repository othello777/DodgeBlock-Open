# DodgeBlock-Open
The public open-source version of Dodgeblock  
  
Due to the nature of secret codes, I cannot release all of the code, but I can put all of it except for that part. Feel free to check out my horrible coding and submit pull requests if you feel up to the task. If you compile the game from source you _will not have access to secret codes_ and _will not be eligible for the leaderboard._ But you can still have fun. The mobile app is the same code as it never had secret codes.

## Building

### Windows
Installing Visual Studio is probably the easiest way. Anything since 2017 should work, just import the C# project for ez win.

### Linux
Probably the easiest way to build DodgeBlock Console is with the dotnet 6.0 SDK. just get that and run `dotnet build`. if that doesn't work, change the target framework version in the csproj file to `net6.0`
