using System.Text.Json.Serialization;

namespace Lemmy.Net.Client.Models;

public class PrivateMessageCreated
{
    public UserRoot Recipient { get; set; }
    public UserRoot Creator { get; set; }
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