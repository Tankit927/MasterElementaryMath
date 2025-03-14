# MasterElementaryMath
Console app to practice elmentary operations like addition. All you have to do is solve as many questions as you can within the set time. And check your score.

## Known issues
- Make sure that window size is sufficiently large so that you don't go exceed the size of window or bad things will happen.
- The timer shows the total time you'll get and it doesn't countdown because I am too dumb to implement that.
- Currently only do addition of two random 2-digit +ve integers.

## First Release info:
| Architecture | size (in MB) | bin | dll | json | self contained | SHA 256 |
| :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| win_x64 | 0.07 | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | | AF554C88C6B9A01F685E4B76498A0BF7EAE9B08094A892F10DBD7742FD1E68C9 |
| win_x64_self_contained | 31.69 | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | 4C7D1B8E714063F59D4EE935A3F749FCBD30D63EC791B51BA9F35AF12C77CA0B |
| linux_x64 | 0.03 | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | | 817A071A3F9918DA5C69D847843BE65DC29DE45B1AF4B95FCB0E870CC01EE899 |
| linux_x64_self_contained | 31.02 | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | EAC51873B71689131F26F28D974D46838BC4522ADAB248C9740E48C95504E54B |

## Prerequisite
- Download [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download)
- Add its path in environment variables.
    - For Windows 10 & above:
         - Type *environment variables* in search bar.
         - Advanced -> Environment Variables
         - Edit System Variables -> Path
         - New -> paste the path. For me it is `C:\Programs Files\dotnet\`
    - For linux *(debian 12)*
         - Add path in appropriate configuration file.
         - I personally have to add path in `/etc/profile` like this. `PATH=/directory_where_I_have_downloaded_dotnet:some_other_path:more_other_paths`

## Note
- .NET 8.0 Runtime need to be installed on the system and should be accessible by including its path in environment variables *(recommended)*.
- Or download and run the self-contained file which has .NET 8.0 Runtime included in it.
- You can also run it using `dotnet MasterElementaryMath.dll`. It requires *ElementaryMath.runtimeconfig.json* to be present in the same directory as *ElementaryMath.dll* and of course .NET 8.0 Runtime should be accessible.
