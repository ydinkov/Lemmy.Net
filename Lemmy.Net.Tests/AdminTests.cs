using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;

public class AdminTests : AbstractTest
{
    [Fact]
    public async Task GetTest()
    {
        var communities = await _lemmy.GetCommunitiesAsync();
        communities.Communities.Should().HaveCountGreaterThan(0);
    }

}