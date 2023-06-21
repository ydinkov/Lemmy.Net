namespace Lemmy.Net.Client.Models;

public class CreatePrivateMessage
{
    public string Content { get; set; } = string.Empty;
    public int Recipient { get; set; }
}

public class CreatePrivateMessageReport
{
    public int PrivateMessageId { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class DeletePrivateMessage
{
    public bool Deleted { get; set; }
    public int PrivateMessageId { get; set; }
}

public class EditPrivateMessage
{
    public string Content { get; set; } = string.Empty;
    public int PrivateMessageId { get; set; }
}