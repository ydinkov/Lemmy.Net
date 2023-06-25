using System.Text.Json.Serialization;
using Lemmy.Net.Client.Models;

public class Community
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Removed { get; set; }
    public DateTime Published { get; set; }
    public DateTime? Updated { get; set; }
    public bool Deleted { get; set; }
    public bool Nsfw { get; set; }
    [JsonPropertyName("actor_id")] public string ActorId { get; set; }
    public bool Local { get; set; }
    public object Icon { get; set; }
    public object Banner { get; set; }
    public bool Hidden { get; set; }

    [JsonPropertyName("posting_restricted_to_mods")]
    public bool PostingRestrictedToMods { get; set; }

    [JsonPropertyName("instance_id")] public int InstanceId { get; set; }
}

public class Counts
{
    public int Id { get; set; }
    public int CommunityId { get; set; }
    public int Subscribers { get; set; }
    public int Posts { get; set; }
    public int Comments { get; set; }
    public DateTime Published { get; set; }
    public int UsersActiveDay { get; set; }
    public int UsersActiveWeek { get; set; }
    public int UsersActiveMonth { get; set; }
    public int UsersActiveHalfYear { get; set; }
}

public class CommunityRoot
{
    public Community Community { get; set; }
    public string Subscribed { get; set; }
    public bool Blocked { get; set; }
    public Counts Counts { get; set; }
}

public class FollowCommunity
{
    public int CommunityId { get; set; }
    public bool Follow { get; set; }
}


public class CommunitiesEnvelope
{
    public List<CommunityRoot> Communities { get; set; }
}

public class CommunityEnvelope
{
    [JsonPropertyName("community_view")] public CommunityRoot CommunityView { get; set; }
}

public class CreateCommunity
{
    public string? Banner { get; set; }
    public string? Description { get; set; }
    public int[]? DiscussionLanguages { get; set; }
    public string? Icon { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool? Nsfw { get; set; }
    public bool? PostingRestrictedToMods { get; set; }
    public string Title { get; set; } = string.Empty;
}

public class EditCommunity
{
    public string? Banner { get; set; }
    public int CommunityId { get; set; }
    public string? Description { get; set; }
    public int[]? DiscussionLanguages { get; set; }
    public string? Icon { get; set; }
    public bool? Nsfw { get; set; }
    public bool? PostingRestrictedToMods { get; set; }
    public string? Title { get; set; }
}

public class BanUser
{
    public bool Ban { get; set; }
    public int CommunityId { get; set; }
    public int? Expires { get; set; }
    public int PersonId { get; set; }
    public string? Reason { get; set; }
    public bool? RemoveData { get; set; }
}

public class BanResponse
{
    public bool Banned { get; set; }
    [JsonPropertyName("person_view")] public UserRoot PersonView { get; set; }
}


public class CommunityBlock
{
    public bool Blocked { get; set; }
    [JsonPropertyName("community_view")] public UserRoot CommunityView { get; set; }
}