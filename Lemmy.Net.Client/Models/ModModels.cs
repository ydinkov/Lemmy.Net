namespace Lemmy.Net.Client.Models;

public class AddModToCommunity
{
    public bool Added { get; set; }
    public int CommunityId { get; set; }
    public int PersonId { get; set; }
}


public class CommunityModEnvelope
{
    public IList<CommunityModRoot> Moderators { get; set; }
}

public class CommunityModRoot
{
    public Community Community { get; set; }
    public User Moderator { get; set; }
}