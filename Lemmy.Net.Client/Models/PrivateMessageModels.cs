using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Client.Models;

public class PrivateMessageRoot
{
    public UserRoot Recipient { get; set; }
    public UserRoot Creator { get; set; }

    [JsonPropertyName("private_message")]
    public PrivateMessage PrivateMessage { get; set; }
}

public class PrivateMessagesEnvelope
{
    [JsonPropertyName("private_messages")]
    public IList<PrivateMessageRoot> PrivateMessages { get; set; } 
}

public class PrivateMessageReportsEnvelope
{
    [JsonPropertyName("private_messages")]
    public IList<PrivateMessageReportRoot> PrivateMessages { get; set; }
}

public class PrivateMessageEnvelope
{
    [JsonPropertyName("private_message")]
    public PrivateMessageRoot PrivateMessage { get; set; }
}

    public class PrivateMessageReportEnvelope
{
    public PrivateMessageReportRoot PrivateMessageReport { get; set; }
}

public class PrivateMessageReportRoot
{
    public User Creator { get; set; }
    [JsonPropertyName("private_message")] public PrivateMessage PrivateMessage { get; set; }
    [JsonPropertyName("private_message_creator")] public User PrivateMessageCreator { get; set; }
    [JsonPropertyName("private_message_report")] public PrivateMessageReport PrivateMessageReport { get; set; }
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
    [JsonPropertyName("ap_id")] public string ApId { get; private set; } = string.Empty;
     public string Content { get; private set; } = string.Empty;
    [JsonPropertyName("creator_id")] public int CreatorId { get; private set; }
     public bool Deleted { get; private set; }
     public int Id { get; private set; }
     public bool Local { get; private set; }
    public string Published { get; private set; } = string.Empty;
    public bool Read { get; private set; }
    [JsonPropertyName("recipient_id")] public int RecipientId { get; private set; }
    public string? Updated { get; private set; }
}