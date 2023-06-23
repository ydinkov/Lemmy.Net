using System.Text.Json.Serialization;

namespace Lemmy.Net.Client.Models;

public class User
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public bool Banned { get; set; }
        public DateTime Published { get; set; }
        public DateTime? Updated { get; set; }
        public string ActorId { get; set; }
        public string Bio { get; set; }
        public bool Local { get; set; }
        public string Banner { get; set; }
        public bool Deleted { get; set; }
        public string InboxUrl { get; set; }
        public string SharedInboxUrl { get; set; }
        public string MatrixUserId { get; set; }
        public bool Admin { get; set; }
        public bool BotAccount { get; set; }
        public DateTime? BanExpires { get; set; }
        public int InstanceId { get; set; }
}

public class UserEnvelope
{
    public PersonRoot Person { get; set; }
}

public class DeleteAccountResponse
{
    public IList<PersonRoot> Banned { get; set; }
}


public class UserRoot
{
    public User Moderator { get; set; }
    public Community Community { get; set; }
}

public class PersonRoot
{
    public User Person { get; set; }
    public Counts Counts { get; set; }
}


public class FollowCommunity
{
    public int CommunityId { get; set; }
    public bool Follow { get; set; }
}


public class Login
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class LoginResponse
{
    public string Jwt { get; set; }
}



public class UserSettings
{
    [JsonPropertyName("accepted_application")] public bool AcceptedApplication { get; set; }
    [JsonPropertyName("default_listing_type")] public int DefaultListingType { get; set; }
    [JsonPropertyName("default_sort_type")] public int DefaultSortType { get; set; }
    public string? Email { get; set; }
    [JsonPropertyName("email_verified")] public bool EmailVerified { get; set; }
     public int Id { get; set; }
    [JsonPropertyName("interface_language")] public string InterfaceLanguage { get; set; }
    [JsonPropertyName("person_id")] public int PersonId { get; set; }
    [JsonPropertyName("send_notifications_to_email")] public bool SendNotificationsToEmail { get; set; }
    [JsonPropertyName("show_avatars")] public bool ShowAvatars { get; set; }
    [JsonPropertyName("show_bot_accounts")] public bool ShowBotAccounts { get; set; }
    [JsonPropertyName("show_new_post_notifs")] public bool ShowNewPostNotifs { get; set; }
    [JsonPropertyName("show_nsfw")] public bool ShowNsfw { get; set; }
    [JsonPropertyName("show_read_posts")] public bool ShowReadPosts { get; set; }
    [JsonPropertyName("show_scores")] public bool ShowScores { get; set; }
    public string Theme { get; set; }
    [JsonPropertyName("validator_time")] public string ValidatorTime { get; set; }
}


public class BanResponse
{
    [JsonPropertyName("person_view")]public PersonRoot PersonView { get; set; }
}

public class BlockUser
{
    public bool Blocked { get; set; }
    [JsonPropertyName("person_view")]public PersonRoot PersonView { get; set; }
}