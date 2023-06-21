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
    }
}
```

## Supports
- GET Posts for community
- GET Post
- GET Communities
- Create Post
- Delete Post

## TODO
- Create Comments