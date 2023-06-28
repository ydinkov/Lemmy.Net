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

public class RegistrationApplicationsEnvelope
{
    public IList<RegistrationApplicationRoot> RegistrationApplications { get; set; }
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
    public UserSettings CreatorLocalUser { get; set; }
    public RegistrationApplication RegistrationApplication { get; private set; } = null!;
}


public class RegistrationApplicationsRequest
{
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public bool? UnreadOnly { get; set; }
}

public class RegistrationApplication
{
    public int AdminId { get; private set; }
    public string Answer { get; private set; } = string.Empty;
    public string? DenyReason { get; private set; }
    public int Id { get; private set; }
    public int LocalUserId { get; private set; }
    public string Published { get; private set; } = string.Empty;
}
    
public class UnreadRegistrationApplicationCount
{
    public int RegistrationApplications { get; set; }
}