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
    public AdminComponent.RegistrationApplication RegistrationApplication { get; private set; } = null!;
}