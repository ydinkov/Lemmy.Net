using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;

public class UserTests : AbstractTest
{
    [Fact]
    public async Task GetCaptcha()
    {
        //var bannedUsers = await _lemmy.User.GetBanned();
        //bannedUsers.Banned.Should().NotBeNull();
    }
}