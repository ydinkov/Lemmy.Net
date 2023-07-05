using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Client.Models;

public class PrivateMessageRoot
{
    public User Recipient { get; set; }
    public User Creator { get; set; }

    public PrivateMessage PrivateMessage { get; set; }
}



public class PrivateMessagesEnvelope
{
    public IList<PrivateMessageRoot> PrivateMessages { get; set; } 
}

public class PrivateMessageReportsEnvelope
{
    public IList<PrivateMessageReportRoot> PrivateMessageReports { get; set; }
}

public class PrivateMessageEnvelope
{
    public PrivateMessageRoot PrivateMessageView  { get; set; }
}

    public class PrivateMessageReportEnvelope
{
    public PrivateMessageReportRoot PrivateMessageReport { get; set; }
}

public class PrivateMessageReportRoot
{
    public User Creator { get; set; }
    public PrivateMessage PrivateMessage { get; set; }
    public User PrivateMessageCreator { get; set; }
    public PrivateMessageReport PrivateMessageReport { get; set; }
    public User Resolver { get; set; }
}

public class PrivateMessageReport
{
    [JsonPropertyName("creator_id")] public int CreatorId { get; set; }
    public int Id { get; set; }
    [JsonPropertyName("original_pm_text")] public string OriginalPmText { get; set; }
    [JsonPropertyName("private_message_id")] public int PrivateMessageId { get; set; }
    public string Published { get; set; }
    public string Reason { get; set; }
    public bool Resolved { get; set; }
    [JsonPropertyName("resolver_id")] public int? ResolverId { get; set; }
    public string? Updated { get; set; }
}

public class PrivateMessage
{
     public string ApId { get;  set; }
     public string Content { get;  set; }
    public int CreatorId { get;  set; }
     public bool Deleted { get;  set; }
     public int Id { get; set ; }
     public bool Local { get;  set; }
    public string Published { get;  set; }
    public bool Read { get; set ; }
    public int RecipientId { get;  set; }
    public string? Updated { get;  set; }
}

public class PrivateMessageReportsRequest
{
    
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public bool? UnresolvedOnly { get; set; }

}

public class PrivateMessagesRequest
{
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public bool? UnreadOnly { get; set; }

    
}