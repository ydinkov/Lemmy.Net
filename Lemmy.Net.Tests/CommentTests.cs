using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;

public class CommentTests : AbstractTest
{
    [Fact]
    public async Task GetComments()
    {
        var comments = await _lemmy.Comment.List(new CommentsRequest());
        comments.Comments.Should().NotBeEmpty();
        comments.Comments.Should().AllSatisfy(x => x.Should().NotBeNull());
    }
    
    
    [Fact]
    public async Task QueryComments()
    {
        var comments = await _lemmy.Comment.List(new CommentsRequest{CommunityId = 2});
        comments.Comments.Should().NotBeEmpty();
        comments.Comments.Should().AllSatisfy(x => x.Community.Id.Should().Be(2));
    }
    [Fact]
    public async Task QueryComments2()
    {
        var comments = await _lemmy.Comment.List(new CommentsRequest{CommunityId = 2,Limit = 20});
        comments.Comments.Should().NotBeEmpty();
        comments.Comments.Should().HaveCount(20);
        comments.Comments.Should().AllSatisfy(x => x.Community.Id.Should().Be(2));
    }
    


}