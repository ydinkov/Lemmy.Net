[![Nuget](https://img.shields.io/nuget/v/Lemmy.Net.Client)](https://www.nuget.org/packages/Lemmy.Net.Client)
<img src="logo.png" width="200"/>

# A (WIP) DI http client for Lemmy in dotnet

## Usage

Run 
```ps1
dotnet add package Lemmy.Net.Client
```

Add this to you Startup

```cs

var services = new ServiceCollection();

services.AddLemmyClient(
    new Uri("<LEMMY INSTANCE URL>"),
    "<USERNAME>",
    "<PASSWORD>",
    //Optionally, add a pair of methods to read and write tokens.
    //This avoid having to reauthenticate on every request
    //WARNING: The file IO below is for demo purposes only!
    //please use something other than files to save your tokens!
    async username => File.Exists($"{username}.txt") ? File.ReadAllText($"{username}.txt") : "",                
    (username, jwtToken) =>  File.WriteAllText($"{username}.txt", jwtToken)                
);
var provider = services.BuildServiceProvider();
```

Then start the service
```cs
var lemmyService = provider.GetRequiredService<ILemmyService>();
```

or use it in your DI consumers

```cs
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    public class YourController : Controller
    {
        private readonly ILemmyService _lemmyService;

        public YourController(ILemmyService lemmyService)
        {
            _lemmyService = lemmyService;
        }

        // Your action methods go here
        public void DoAThing(){
            //Prints the names of all the communities on the instance
            foreach(var c in _lemmyService.Community.List().Communities)
            {
                Console.WriteLine(c.Community.Name);
            }
        }
        
    }
}
```

## Supports
- CRUD for Communities
- CRUD for Posts (and voting)
- CRUD for Comments (and voting)
- CRUD for Private messages (and reporting)
- Site actions
- Reporting and Resolving
- Modding and Admin actions
- Captachs, registrations, password resets and email validation
- Replies, Mentions and Notifications
- Exponential retry policy

## TODO
- Better querying
- Test Coverage
- Model reuse
