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

    public string ApId { get; set; }

    public string Content { get; set; }

    public int CreatorId { get; set; }
    public bool Deleted { get; set; }
    public bool Distinguished { get; set; }
    public int LanguageId { get; set; }
    public bool Local { get; set; }
    public string Path { get; set; }

    public int PostId { get; set; }

    public DateTime Published { get; set; }
    public bool Removed { get; set; }
    public DateTime? Updated { get; set; }
}

public class CommentCounts
{public int ChildCount { get; set; }
public int CommentId { get; set; }

    public int Downvotes { get; set; }
    public int Id { get; set; }
    public int Score { get; set; }
    public int Upvotes { get; set; }
public int HotRank { get; set; }
}

public class CommentRoot
{
    public Comment Comment { get; set; }
    public Community Community { get; set; }
    public CommentCounts Counts { get; set; }
    public User Creator { get; set; }

    public bool CreatorBannedFromCommunity { get; set; }

    public bool CreatorBlocked { get; set; }

    public int MyVote { get; set; }
    public Post Post { get; set; }
    public bool Saved { get; set; }
    public string Subscribed { get; set; }
}

public class CommentReplyRoot
{
    public Comment Comment { get; set; }
    public CommentReply CommentReply { get; set; }
    public Community Community { get; set; }
    public CommentCounts Counts { get; set; }
    public User Creator { get; set; }
    public bool CreatorBannedFromCommunity { get; set; }
    public bool CreatorBlocked { get; set; }
    public int MyVote { get; set; }
    public Post Post { get; set; }
    public User Recipient { get; set; }
    public bool Saved { get; set; }
    public string Subscribed { get; set; }
}

public class RepliesEnvelope
{
    public IList<CommentReplyRoot> Replies { get; set; }
}

public class CommentReply
{
    public int CommentId { get; set; }
    public int Id { get; set; }
    public string Published { get; set; }
    public bool Read { get; set; }
    public int RecipientId { get; set; }
}

public class CommentReportRoot
{
    public Comment Comment { get; set; }
    public User CommentCreator { get; set; }
    public CommentReport CommentReport { get; set; }
    public Community Community { get; set; }
    public CommentCounts Counts { get; set; }
    public User Creator { get; set; }
    public bool CreatorBannedFromCommunity { get; set; }
    public int? MyVote { get; set; }
    public Post Post { get; set; }
    public User Resolver { get; set; }
}

public class CommentReport
{
    public int CommentId { get; set; }
    public int CreatorId { get; set; }
    public int Id { get; set; }
    public string OriginalCommentText { get; set; }
    public string Published { get; set; }
    public string Reason { get; set; }
    public bool Resolved { get; set; }
    public int? ResolverId { get; set; }
    public string? Updated { get; set; }
}

public class CommentEnvelope
{
    public CommentRoot CommentView { get; set; }
    public string? FormId { get; set; }
    public int[] RecipientIds { get; set; }
}

public class CommentReportsEnvelope
{
    public IList<CommentReportRoot> CommentReports { get; set; }
}

public class CommentReportEnvelope
{
    public CommentReportRoot CommentReportView { get; set; }
}

public class CommentReportsRequest
{
    public int? CommunityId { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public bool? UnresolvedOnly { get; set; }
}

public class CommentsRequest
{
    public int? CommunityId { get; set; }
    
    public string? CommunityName { get; set; }
    public int? Limit { get; set; }
    
    public int? MaxDepth { get; set; }
    public int? Page { get; set; }
    
    public int? ParentId { get; set; }
    public int? PostId { get; set; }
    public int? SavedOnly { get; set; }
    public string? Sort { get; set; }

    
    public string Type { get; set; }

}