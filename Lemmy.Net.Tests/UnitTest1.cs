using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Nibblebit.Lemmy.Tests
{
    public class UnitTest1
    {
        private IConfiguration _configuration;

        private Dictionary<string, string> _testConfig;

        public UnitTest1()
        {
            _testConfig = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("local.config.json"));
        }

        [Fact]
        public async Task CommunityAsync()
        {


            var services = new ServiceCollection();

            services.AddLemmyClient(
                new Uri("https://programming.dev/"),
                _testConfig["username"],
                _testConfig["password"],
                async username => File.Exists($"{username}.txt") ? File.ReadAllText($"{username}.txt") : "",
                (username, jwtToken) => File.WriteAllText($"{username}.txt", jwtToken)
            );
            var provider = services.BuildServiceProvider();
            var lemmyService = provider.GetRequiredService<ILemmyService>();

            var comities = await lemmyService.GetComunitiesAsync();

            comities.Communities.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task PostTestAsync()
        {


            var services = new ServiceCollection();

            services.AddLemmyClient(
                new Uri("https://programming.dev/"),
                _testConfig["username"],
                _testConfig["password"],
                async username => File.Exists($"{username}.txt") ? File.ReadAllText($"{username}.txt") : "",
                (username, jwtToken) => File.WriteAllText($"{username}.txt", jwtToken)
            );
            var provider = services.BuildServiceProvider();
            var lemmyService = provider.GetRequiredService<ILemmyService>();

            var posts = await lemmyService.GetPostsAsync("15");

            posts.Posts.Should().HaveCountGreaterThan(0);
        }
    }
}