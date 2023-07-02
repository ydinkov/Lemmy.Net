using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;

public class PostTests : AbstractTest
{
    [Fact]
    public async Task GetPostsTest()
    {
        var posts = await _lemmy.Post.List();
        posts.Posts.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetPostReportsTest()
    {
        var posts = await _lemmy.Post.Reports();
        posts.PostReports.Should().NotBeNull();
    }
    

    [Fact]
    public async Task Like()
    {
        var posts = await _lemmy.Post.List();
        var post = posts.Posts.Last();
        var l = await _lemmy.Post.Like(post.Post.Id);
        l.Should().BeTrue();
        
        var d = await _lemmy.Post.Dislike(post.Post.Id);
        d.Should().BeTrue();
        
        var r = await _lemmy.Post.Reset(post.Post.Id);
        r.Should().BeTrue();
    }
    
    

    //[Fact]
    public async Task CreatePostTestAsync()
    {
        Console.WriteLine("Test post create");
        var post = new CreatePost
        {
            CommunityId = 41372,
            Name = "Unit Test Post3",
            Body = "Hello this was created for a unit test"
        };
        var res = await _lemmy.Post.Create(post);//.CreatePostsAsync(post);
        res.PostView.Post.Should().NotBeNull();
        
        //var d = await _lemmy.Post.Remove(res.PostView.Post.Id);//.DeletePostsAsync();
        //d.PostView.Post.Deleted.Should().BeTrue();

    }
}