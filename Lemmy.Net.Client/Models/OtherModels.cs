using System.Text.Json.Serialization;

namespace Lemmy.Net.Client.Models;

public class ApproveRegistrationApplication
{
    public bool Approve { get; set; }
    public string? DenyReason { get; set; }
    public int Id { get; set; }
}

public class BanFromCommunity
{
    public bool Ban { get; set; }
    public int CommunityId { get; set; }
    public int? Expires { get; set; }
    public int PersonId { get; set; }
    public string? Reason { get; set; }
    public bool? RemoveData { get; set; }
}

public class BanPerson
{
    public bool Ban { get; set; }
    public int? Expires { get; set; }
    public int PersonId { get; set; }
    public string? Reason { get; set; }
    public bool? RemoveData { get; set; }
}

public class BlockCommunity
{
    public bool Block { get; set; }
    public int CommunityId { get; set; }
}

public class ChangePassword
{
    public string NewPassword { get; set; }
    public string NewPasswordVerify { get; set; }
    public string OldPassword { get; set; }
}

public class SearchRequest
{
    public int? CommunityId { get; set; }
    public string? CommunityName { get; set; }
    public int? CreatorId { get; set; }
    public int? Limit { get; set; }
    public string? ListingType { get; set; }
    public string Q { get; set; }
    public string? SortType { get; set; }
    [JsonPropertyName("type_")] public string? Type { get; set; }
}

public class ReportCountRequest
{
    public int? CommunityId { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public bool? UnresolvedOnly { get; set; }
}

public class SearchEnvelope
{
    public IList<CommentRoot> Comments { get; set; }
    public IList<CommunityRoot> Communities { get; set; }
    public IList<PostRoot> Posts { get; set; }
    public string Type { get; set; }
    public IList<ModeratorRoot> Users { get; set; }
}