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
    

}