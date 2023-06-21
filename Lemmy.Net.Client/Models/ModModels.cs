namespace Lemmy.Net.Client.Models;

public class AddModToCommunity
{
    public bool Added { get; set; }
    public int CommunityId { get; set; }
    public int PersonId { get; set; }
}