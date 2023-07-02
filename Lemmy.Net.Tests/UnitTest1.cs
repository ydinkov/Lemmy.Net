using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Nibblebit.Lemmy.Tests
{
    public class UnitTest1
    {
        private IConfiguration _configuration;

        private Dictionary<string, string> _testConfig;

        private ILemmyService _lemmy;
        public UnitTest1()
        {
            string configStr;
            try
            {
                configStr = File.ReadAllText("config.json");
            }
            catch
            {
                Console.WriteLine("Couldn't find config.json, loading local.");
                configStr = File.ReadAllText("local.config.json");
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

      
        
        //[Fact]
        public async Task CreateCommunityAsync()
        {
            //41394
            var c = new CreateCommunity
            {
                Name = "TestPleaseIgnore8", Title = "Bla8"
            };
            var communities = await _lemmy.Community.Create(c);
            try
            {
                communities.CommunityView.Community.Id.Should().NotBe(null);
            }
            catch (Exception e)
            {
                e.Should().BeNull();
            }
            var r = await _lemmy.Community.Delete(communities.CommunityView.Community.Id);
            r.Should().BeTrue();
        }

        [Fact]
        public async Task GetPostTestAsync()
        {
            var posts = await _lemmy.Post.Get(2);
            posts.PostView.Should().NotBeNull();
        }
        
        [Fact]
        public async Task GetCommentsTestAsync()
        {
            //test post '2'
            var comments = await _lemmy.Comment.List(new CommentsRequest{CommunityId = 2});
            comments.Comments.Should().NotBeNull();
        }
    }
}