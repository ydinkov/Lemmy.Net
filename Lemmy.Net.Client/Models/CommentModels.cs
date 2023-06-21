using System.Text.Json.Serialization;

namespace Lemmy.Net.Client.Models;

public class CreateComment
{
    public string Content { get; set; }
    public string? FormId { get; set; }
    public int? LanguageId { get; set; }
    public int? ParentId { get; set; }
    public int PostId { get; set; }
}



public class EditComment
{
    public int CommentId { get; set; }
    public string? Content { get; set; }
    public bool? Distinguished { get; set; }
    public string? FormId { get; set; }
    public int? LanguageId { get; set; }
}

public class CommentsEnvelope
{
    public List<CommentRoot> Comments { get; set; }
}

public class Comment
{
    public int Id { get; set; }
    
    [JsonPropertyName("ap_id")]
    public string ApId { get; set; }
    
    public string Content { get; set; }
    
    [JsonPropertyName("creator_id")]
    public int CreatorId { get; set; }
    public bool Deleted { get; set; }
    public bool Distinguished { get; set; }
    public int LanguageId { get; set; }
    public bool Local { get; set; }
    public string Path { get; set; }
    
    [JsonPropertyName("post_id")]
    public int PostId { get; set; }
    
    public DateTime Published { get; set; }
    public bool Removed { get; set; }
    public DateTime? Updated { get; set; }
}

public class CommentCounts
{
    [JsonPropertyName("child_count")]
    public int ChildCount { get; private set; }
    
    [JsonPropertyName("comment_id")]
    public int CommentId { get; private set; }
    
    public int Downvotes { get; private set; }
    public int Id { get; private set; }
    public int Score { get; private set; }
    public int Upvotes { get; private set; }
    
    [JsonPropertyName("hot_rank")]
    public int HotRank { get; set; }
}
public class CommentRoot
{
    public Comment Comment { get; set; }
    public Community Community { get; set; }
    public CommentCounts Counts { get; set; } 
    public User Creator { get; set; }
    
    [JsonPropertyName("creator_banned_from_community")]
    public bool CreatorBannedFromCommunity { get; set; }
    
    [JsonPropertyName("creator_blocked")]
    public bool CreatorBlocked { get; set; }
    
    public int MyVote { get; private set; }
    public Post Post { get; set; }
    public bool Saved { get; set; }
    public string Subscribed { get; set; }
}

