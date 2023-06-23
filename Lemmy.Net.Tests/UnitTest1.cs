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

        [Fact]
        public async Task CommunityAsync()
        {
            var communities = await _lemmy.GetCommunitiesAsync();
            communities.Communities.Should().HaveCountGreaterThan(0);
        }
        
        [Fact]
        public async Task CreateCommunityAsync()
        {
            //41394
            var c = new CreateCommunity
            {
                Name = "TestPleaseIgnore5", Title = "Bla2"
            };
            var communities = await _lemmy.Community.Create(c);
            communities.CommunityView.Community.Id.Should().NotBe(null);
            var r = await _lemmy.Community.Delete(communities.CommunityView.Community.Id);
            r.Should().BeTrue();
        }


        [Fact]
        public async Task GetPostsTestAsync()
        {
            //test community '15'
            var posts = await _lemmy.GetPostsAsync();
            posts.Posts.Should().HaveCountGreaterThan(0);
        }
        
        [Fact]
        public async Task GetPostTestAsync()
        {
            //test post '2'
            var posts = await _lemmy.GetPostAsync(2);
            posts.Post.Should().NotBeNull();
        }
        
        [Fact]
        public async Task GetCommentsTestAsync()
        {
            //test post '2'
            
            var comments = await _lemmy.Comment.List("community=2");
            comments.Comments.Should().NotBeNull();
        }
        
        [Fact]
        public async Task CreatePostTestAsync()
        {
            var post = new CreatePost
            {
                CommunityId = 41372,
                Name = "Unit Test Post",
                Body = "Hello this was created for a unit test"
            };
            var res = await _lemmy.CreatePostsAsync(post);
            res.Post.Should().NotBeNull();

            _lemmy.DeletePostsAsync(res.Post.Post.Id);

        }
    }
}