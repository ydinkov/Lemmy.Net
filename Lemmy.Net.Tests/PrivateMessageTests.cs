using FluentAssertions;
using Lemmy.Net.Client.Models;

namespace Nibblebit.Lemmy.Tests;

public class PrivateMessageTests : AbstractTest
{
    [Fact]
    public async Task GetPrivateMessageTests()
    {
        var pms = await _lemmy.PrivateMessage.List();
        pms.PrivateMessages.Should().NotBeNull();
    }
    
    
    [Fact]
    public async Task CreatePrivateMessageTests()
    {
        var user = await _lemmy.User.GetDetails(new UserDetailsRequest{ Username = "nibblebot" });
        var pms = await _lemmy.PrivateMessage.Create(user.PersonView.Person.Id,"test message");
        pms.PrivateMessageView.PrivateMessage.Should().NotBeNull();
        var res = await _lemmy.PrivateMessage.Delete(pms.PrivateMessageView.PrivateMessage.Id);
        res.Should().NotBeNull();
    }

}