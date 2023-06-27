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
        var comments = await _lemmy.Comment.List("");
        comments.Comments.Should().NotBeEmpty();
    }
    

}