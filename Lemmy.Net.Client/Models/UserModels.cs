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
    public UserRoot User { get; set; }
}

public class DeleteAccountResponse
{
    public IList<UserRoot> Banned { get; set; }
}

public class ModeratorRoot
{
    public User Moderator { get; set; }
    public Community Community { get; set; }
}

public class UserRoot
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


public class LoginEnvelope
{
    public string Jwt { get; set; }
}

public class UserDetailsEnvelope
{
    public IList<CommentRoot> Comments { get; set; }
    public IList<CommunityModRoot> Moderates { get; set; }
    public UserRoot PersonView { get; set; }
    public IList<PostRoot> Posts { get; set; }
}

public class UserDetailsRequest
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
    
    public bool AcceptedApplication { get; set; }

    
    public int DefaultListingType { get; set; }

    
    public int DefaultSortType { get; set; }

    public string? Email { get; set; }
    public bool EmailVerified { get; set; }
    public int Id { get; set; }

    
    public string InterfaceLanguage { get; set; }

    
    public int PersonId { get; set; }

    
    public bool SendNotificationsToEmail { get; set; }

    public bool ShowAvatars { get; set; }

    
    public bool ShowBotAccounts { get; set; }

    
    public bool ShowNewPostNotifs { get; set; }

    public bool ShowNsfw { get; set; }
    public bool ShowReadPosts { get; set; }
    public bool ShowScores { get; set; }
    public string Theme { get; set; }
    public string ValidatorTime { get; set; }
}

public class BanResponse
{
    public UserRoot UserView { get; set; }
}

public class BlockUser
{
    public bool Blocked { get; set; }
    public UserRoot UserView { get; set; }
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
    public Comment Comment { get; set; }
    public Community Community { get; set; }
    public CommentCounts Counts { get; set; }
    public User Creator { get; set; }
    public bool CreatorBannedFromCommunity { get; set; }
    public bool CreatorBlocked { get; set; }
    public int? MyVote { get; set; }
    public UserMention PersonMention { get; set; }
    public Post Post { get; set; }
    public User Recipient { get; set; }
    public bool Saved { get; set; }
    public string Subscribed { get; set; }
}

public class UserMention
{
    public int CommentId { get; set; }
    public int Id { get; set; }
    public DateTime Published { get; set; }
    public bool Read { get; set; }
    public int RecipientId { get; set; }
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
    public int CommentReports { get; set; }
    public int? CommunityId { get; set; }
    public int PostReports { get; set; }
    public int? PrivateMessageReports { get; set; }
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