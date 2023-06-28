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
        var communities = await _lemmy.Community.List(new());
        communities.Communities.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetCommunity()
    {
        var community = await _lemmy.Community.Get(name:"test_new_comm");
        community.CommunityView.Community.Title.Should().Be("Test New Community");
    }
    
    [Fact]
    public async Task FollowCommunities()
    {
        var communities = await _lemmy.Community.List(new CommunitiesRequest{Type = "Local"});
        var someCommunity = communities.Communities.Last().Community.Id;
        var followed = await _lemmy.Community.Follow(someCommunity);
        followed.CommunityView.Subscribed.Should().Be("Subscribed");
        var unfollowed = await _lemmy.Community.UnFollow(someCommunity);
        unfollowed.CommunityView.Subscribed.Should().Be("NotSubscribed");
    }

    
    [Fact]
    public async Task GetLocalCommunities()
    {
        var communities = await _lemmy.Community.List(new CommunitiesRequest{Type = "Local"});
        communities.Communities.Should().AllSatisfy(x=>x.Community.Local = true);
    }

    //[Fact]
    public async Task CreateCommunity()
    {
        var community = await _lemmy.Community.Create(new CreateCommunity{Name="NibbleTest3",Title = "NibbleTest3"});

        var del = await _lemmy.Community.Delete(community.CommunityView.Community.Id);
        del.Should().BeTrue();
    }


}