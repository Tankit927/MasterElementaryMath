# MasterElementaryMath
Console app to practice elmentary operations like addition. All you have to do is solve as many questions as you can within the set time. And check your score.

![console app pic](Pics/Pic1.png)

## Known issues
- The timer shows the total time you'll get and it doesn't countdown because I am too dumb to implement that. And after running out of time it doesn't close immediately but waits for last user input, which enables you to have infinite time for your last attempt.
- Currently only do addition of two random 2-digit +ve integers.

## Latest Release info:
| OS | size (in MB) | SHA 256 |
| :---: | :---: | :---: |
| win_x64 | 0.07 |  |
| win_x64_self_contained | 31.69 |  |
| linux_x64 | 0.03 |  |
| linux_x64_self_contained | 31.02 |  |

## Note
- .NET 8.0 Runtime need to be installed on the system and should be accessible by including its path in environment variables to run non-self contained version *(recommended)*.
- Or download and run the self-contained file which has .NET 8.0 Runtime included in it.
- You can also run console app using `dotnet MasterElementaryMath.dll`.

## Prerequisite to run non-self contained version
- Download and install [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download) if not already present.
- To check if dotnet runtime is already present.
  ```
  D:\CSharp\ConsoleApps\MasterElementaryMath>dotnet --list-runtimes
  Microsoft.AspNetCore.App 8.0.7 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 8.0.7 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.WindowsDesktop.App 8.0.7 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  ```
- You only need this one
  ```
  Microsoft.NETCore.App 8.0.7 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  ```
- Add its path in environment variables.
    - For Windows 10 & above:
         - Type *environment variables* in search bar.
         - Advanced -> Environment Variables
         - Edit System Variables -> Path
         - New -> paste the path. For me it is `C:\Programs Files\dotnet\`
    - For linux *(debian 12)*
         - Add path in appropriate configuration file.
         - I personally have to add path in `/etc/profile` like this.
           ```
           PATH=/directory_where_I_have_downloaded_dotnet:some_other_path:more_other_paths
           ```
