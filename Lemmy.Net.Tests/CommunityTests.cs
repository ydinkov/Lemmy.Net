using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;

public class CommunityTests : AbstractTest
{
    [Fact]
    public async Task GetCommunities()
    {
        var communities = await _lemmy.Community.List();
        communities.Communities.Should().NotBeEmpty();
    }
    

}