using System.Text.Json;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;

public class AbstractTest
{
    private IConfiguration _configuration;

    private Dictionary<string, string> _testConfig;

    protected ILemmyService _lemmy;
    public AbstractTest()
    {
        string configStr;
        try
        {
            configStr = File.ReadAllText("local.config.json");
        }
        catch
        {
            Console.WriteLine("Couldn't find config.json, loading local.");
            configStr = File.ReadAllText("prod.config.json");
        }

        _testConfig = JsonSerializer.Deserialize<Dictionary<string, string>>(configStr);
        var services = new ServiceCollection();
        services.AddLemmyClient(
            _testConfig["instanceUrl"],
            _testConfig["username"],
            _testConfig["password"],
            async username => File.Exists($"{username}.txt") ? File.ReadAllText($"{username}.txt") : "",
            (username, jwtToken) => File.WriteAllText($"{username}.txt", jwtToken)
        );
        var provider = services.BuildServiceProvider();
        _lemmy = provider.GetRequiredService<ILemmyService>();
    }
}