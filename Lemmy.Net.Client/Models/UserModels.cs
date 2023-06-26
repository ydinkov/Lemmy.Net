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

public class UsersEnvelope
{
    public IList<User> Persons { get; set; }
}

public class BannedUsersEnvelope
{
    public IList<User> Banned { get; set; }
}

public class Captcha
{
    public string Png { get; set; }
    public string Uuid { get; set; }
    public string? Wav { get; set; }
}

public class CaptchaEnvelope
{
    public Captcha Ok { get; set; }
}

public class Login
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginEnvelope
{
    public string Jwt { get; set; }
}

public class UserDetails
{
    public IList<CommentRoot> Comments { get; set; }
    public IList<CommunityModRoot> Moderates { get; set; }
    [JsonPropertyName("person_view")] public User PersonView { get; set; }
    public IList<PostRoot> Posts { get; set; }
}

public class GetUserDetails
{
    public int? CommunityId { get; set; }
    public int? Limit { get; set; }
    public int? PersonId { get; set; }
    public bool? SavedOnly { get; set; }
    public string Sort { get; set; }
    public string? Username { get; set; }
}

public class UserSettings
{
    [JsonPropertyName("accepted_application")]
    public bool AcceptedApplication { get; set; }

    [JsonPropertyName("default_listing_type")]
    public int DefaultListingType { get; set; }

    [JsonPropertyName("default_sort_type")]
    public int DefaultSortType { get; set; }

    public string? Email { get; set; }
    [JsonPropertyName("email_verified")] public bool EmailVerified { get; set; }
    public int Id { get; set; }

    [JsonPropertyName("interface_language")]
    public string InterfaceLanguage { get; set; }

    [JsonPropertyName("person_id")] public int PersonId { get; set; }

    [JsonPropertyName("send_notifications_to_email")]
    public bool SendNotificationsToEmail { get; set; }

    [JsonPropertyName("show_avatars")] public bool ShowAvatars { get; set; }

    [JsonPropertyName("show_bot_accounts")]
    public bool ShowBotAccounts { get; set; }

    [JsonPropertyName("show_new_post_notifs")]
    public bool ShowNewPostNotifs { get; set; }

    [JsonPropertyName("show_nsfw")] public bool ShowNsfw { get; set; }
    [JsonPropertyName("show_read_posts")] public bool ShowReadPosts { get; set; }
    [JsonPropertyName("show_scores")] public bool ShowScores { get; set; }
    public string Theme { get; set; }
    [JsonPropertyName("validator_time")] public string ValidatorTime { get; set; }
}

public class BanResponse
{
    [JsonPropertyName("person_view")] public PersonRoot PersonView { get; set; }
}

public class BlockUser
{
    public bool Blocked { get; set; }
    [JsonPropertyName("person_view")] public PersonRoot PersonView { get; set; }
}

public class GetUserMentions
{
    public int? Limit { get; set; }
    public string? Sort { get; set; }
    public int? Page { get; set; }
    public bool? UnreadOnly { get; set; }
}

public class UserMentionEnvelope
{
    public UserMentionRoot PersonMentionView { get; set; }
}


public class UserMentionsEnvelope
{
    public IList<UserMentionRoot> Mentions { get; set; }
}

public class UserMentionRoot
{
    public Comment Comment { get; set; } = null!;
    public Community Community { get; set; } = null!;
    public CommentCounts Counts { get; set; } = null!;
    public User Creator { get; set; } = null!;

    [JsonPropertyName("creator_banned_from_community")]
    public bool CreatorBannedFromCommunity { get; set; }

    [JsonPropertyName("creator_blocked")] public bool CreatorBlocked { get; set; }
    [JsonPropertyName("my_vode")] public int? MyVote { get; set; }

    [JsonPropertyName("person_mention")] public UserMention PersonMention { get; set; } = null!;
    public Post Post { get; set; } = null!;
    public User Recipient { get; set; } = null!;
    public bool Saved { get; set; }
    public string Subscribed { get; set; }
}

public class UserMention
{
    [JsonPropertyName("comment_id")] public int CommentId { get; set; }
    public int Id { get; set; }
    public DateTime Published { get; set; }
    public bool Read { get; set; }
    [JsonPropertyName("recipient_id")] public int RecipientId { get; set; }
}

public class GetReplies
{
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public string? Sort { get; set; }
    public bool? UnreadOnly { get; set; }

}

public class ReportCount
{
    public int CommentReports { get; private set; }
    public int? CommunityId { get; private set; }
    public int PostReports { get; private set; }
    public int? PrivateMessageReports { get; private set; }
}
public class UnreadCount
{
    public int Mentions { get; set; }
    public int PrivateMessages { get; set; }
    public int Replies { get; set; }
}

public class RegistrationRequest
{
    public string? CaptchaAnswer { get; set; }
    public string? CaptchaUuid { get; set; }
    public string? Email { get; set; }
    public string? Honeypot { get; set; }
    public string Password { get; set; }
    public string PasswordVerify { get; set; }
    public bool ShowNsfw { get; set; }
    public string Username { get; set; }
}
public class SaveUserSettingsRequest
{
    public string? Avatar { get; set; }
    public string? Banner { get; set; }
    public string? Bio { get; set; }
    public bool? BotAccount { get; set; }
    public int? DefaultListingType { get; set; }
    public int? DefaultSortType { get; set; }
    public int[]? DiscussionLanguages { get; set; }
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public string? InterfaceLanguage { get; set; }
    public string? MatrixUserId { get; set; }
    public bool? SendNotificationsToEmail { get; set; }
    public bool? ShowAvatars { get; set; }
    public bool? ShowBotAccounts { get; set; }
    public bool? ShowNewPostNotifs { get; set; }
    public bool? ShowNsfw { get; set; }
    public bool? ShowReadPosts { get; set; }
    public bool? ShowScores { get; set; }
    public string? Theme { get; set; }

}