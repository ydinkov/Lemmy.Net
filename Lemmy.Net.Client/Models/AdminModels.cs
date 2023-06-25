using System.Text.Json.Serialization;
using Lemmy.Net.Client.Components;

namespace Lemmy.Net.Client.Models;

public class AddAdmin
{
    public bool Added { get; set; }
    public int PersonId { get; set; }
}

public class AdminsEnvelope
{
    public IList<UserRoot> Admins { get; set; }
}


public class ApproveRegistration
{
    public bool Approve { get; set; }
    public string? DenyReason { get; set; }
    public int Id { get; set; }
}

public class RegistrationApplicationEnvelope
{
    [JsonPropertyName("registration_application")]
    private RegistrationApplicationRoot RegistrationApplication { get; set; }
}

public class RegistrationApplicationRoot 
{
     public User? Admin { get; set; }
     public User Creator { get; set; }
    [JsonPropertyName("creator_local_user")] 
    public UserSettings CreatorLocalUser { get; set; }
    [JsonPropertyName("registration_application")] 
    public RegistrationApplication RegistrationApplication { get; private set; } = null!;
}


public class RegistrationApplication
{
    [JsonPropertyName("admin_id")] public int AdminId { get; private set; }
    public string Answer { get; private set; } = string.Empty;
    [JsonPropertyName("deny_reason")] public string? DenyReason { get; private set; }
    public int Id { get; private set; }
    [JsonPropertyName("local_user_id")] public int LocalUserId { get; private set; }
    public string Published { get; private set; } = string.Empty;
}
    
public class UnreadRegistrationApplicationCount
{
    [JsonPropertyName("registration_applications")] 
    public int RegistrationApplications { get; set; }
}