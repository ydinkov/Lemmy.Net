using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Models;

public class CreateSite
{
    public int? ActorNameMaxLength { get; set; }
    public string[]? AllowedInstances { get; set; }
    public bool? ApplicationEmailAdmins { get; set; }
    public string? ApplicationQuestion { get; set; }
    public string? Banner { get; set; }
    public string[]? BlockedInstances { get; set; }
    public string? CaptchaDifficulty { get; set; }
    public bool? CaptchaEnabled { get; set; }
    public bool? CommunityCreationAdminOnly { get; set; }
    public string? DefaultPostListingType { get; set; }
    public string? DefaultTheme { get; set; }
    public string? Description { get; set; }
    public int[]? DiscussionLanguages { get; set; }
    public bool? EnableDownvotes { get; set; }
    public bool? EnableNsfw { get; set; }
    public bool? FederationDebug { get; set; }
    public bool? FederationEnabled { get; set; }
    public int? FederationWorkerCount { get; set; }
    public bool? HideModlogModNames { get; set; }
    public string? Icon { get; set; }
    public string? LegalInformation { get; set; }
    public string Name { get; set; }
    public bool? Instance { get; set; }
    public int? RateLimitComment { get; set; }
    public int? RateLimitCommentPerSecond { get; set; }
    public int? RateLimitImage { get; set; }
    public int? RateLimitImagePerSecond { get; set; }
    public int? RateLimitMessage { get; set; }
    public int? RateLimitMessagePerSecond { get; set; }
    public int? RateLimitPost { get; set; }
    public int? RateLimitPostPerSecond { get; set; }
    public int? RateLimitRegister { get; set; }
    public int? RateLimitRegisterPerSecond { get; set; }
    public int? RateLimitSearch { get; set; }
    public int? RateLimitSearchPerSecond { get; set; }
    public string? RegistrationMode { get; set; }
    public bool? ReportsEmailAdmins { get; set; }
    public string? Sidebar { get; set; }
    public string? SlurFilterRegex { get; set; }
    public string[]? Taglines { get; set; }
}

public class EditSite
{
    public int? ActorNameMaxLength { get; set; }
    public string[]? AllowedInstances { get; set; }
    public bool? ApplicationEmailAdmins { get; set; }
    public string? ApplicationQuestion { get; set; }
    public string? Banner { get; set; }
    public string[]? BlockedInstances { get; set; }
    public string? CaptchaDifficulty { get; set; }
    public bool? CaptchaEnabled { get; set; }
    public bool? CommunityCreationAdminOnly { get; set; }
    public string? DefaultPostListingType { get; set; }
    public string? DefaultTheme { get; set; }
    public string? Description { get; set; }
    public int[]? DiscussionLanguages { get; set; }
    public bool? EnableDownvotes { get; set; }
    public bool? EnableNsfw { get; set; }
    public bool? FederationDebug { get; set; }
    public bool? FederationEnabled { get; set; }
    public int? FederationWorkerCount { get; set; }
    public bool? HideModlogModNames { get; set; }
    public string? Icon { get; set; }
    public string? LegalInformation { get; set; }
    public string? Name { get; set; }
    public bool? Instance { get; set; }
    public int? RateLimitComment { get; set; }
    public int? RateLimitCommentPerSecond { get; set; }
    public int? RateLimitImage { get; set; }
    public int? RateLimitImagePerSecond { get; set; }
    public int? RateLimitMessage { get; set; }
    public int? RateLimitMessagePerSecond { get; set; }
    public int? RateLimitPost { get; set; }
    public int? RateLimitPostPerSecond { get; set; }
    public int? RateLimitRegister { get; set; }
    public int? RateLimitRegisterPerSecond { get; set; }
    public int? RateLimitSearch { get; set; }
    public int? RateLimitSearchPerSecond { get; set; }
    public string RegistrationMode { get; set; }
    public bool? ReportsEmailAdmins { get; set; }
    public string? Sidebar { get; set; }
    public string? SlurFilterRegex { get; set; }
    public string[]? Taglines { get; set; }
}

public class SiteAggregates
{
    public int Comments { get; set; }
    public int Communities { get; set; }
    public int Id { get; set; }
    public int Posts { get; set; }
    public int SiteId { get; set; }
    public int Users { get; set; }
    public int UsersActiveDay { get; set; }
    public int UsersActiveHalfYear { get; set; }
    public int UsersActiveMonth { get; set; }
    public int UsersActiveWeek { get; set; }
}

public class LocalSite
{
    public int ActorNameMaxLength { get; set; }
    public bool ApplicationEmailAdmins { get; set; }
    public string? ApplicationQuestion { get; set; }
    public string CaptchaDifficulty { get; set; }
    public bool CaptchaEnabled { get; set; }
    public bool CommunityCreationAdminOnly { get; set; }
    public string DefaultPostListingType { get; set; }
    public string DefaultTheme { get; set; }
    public bool EnableDownvotes { get; set; }
    public bool EnableNsfw { get; set; }
    public bool FederationDebug { get; set; }
    public bool FederationEnabled { get; set; }
    public bool FederationWorkerCount { get; set; }
    public bool HideModlogModNames { get; set; }
    public int Id { get; set; }
    public string? LegalInformation { get; set; }
    public bool Instance { get; set; }
    public string Published { get; set; }
    public string RegistrationMode { get; set; }
    public bool ReportsEmailAdmins { get; set; }
    public bool RequireEmailVerification { get; set; }
    public int SiteId { get; set; }
    public bool SiteSetup { get; set; }
    public string? SlurFilterRegex { get; set; }
    public string? Updated { get; set; }
}

public class LocalSiteRateLimit
{
    public int Comment { get; set; }
    public int CommentPerSecond { get; set; }
    public int Id { get; set; }
    public int Image { get; set; }
    public int ImagePerSecond { get; set; }
    public int LocalSiteId { get; set; }
    public int Message { get; set; }
    public int MessagePerSecond { get; set; }
    public int Post { get; set; }
    public int PostPerSecond { get; set; }
    public string Published { get; set; }
    public int Register { get; set; }
    public int RegisterPerSecond { get; set; }
    public int Search { get; set; }
    public int SearchPerSecond { get; set; }
    public string? Updated { get; set; }
}

public class Site
{
    public string ActorId { get; set; }
    public string? Banner { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public int Id { get; set; }
    public string InboxUrl { get; set; }
    public int InstanceId { get; set; }
    public string LastRefreshedAt { get; set; }
    public string Name { get; set; }
    public string? Key { get; set; }
    public string PublicKey { get; set; }
    public string Published { get; set; }
    public string? Sidebar { get; set; }
    public string? Updated { get; set; }
}

public class Tagline
{
    public string Content { get; set; }
    public int Id { get; set; }
    public int LocalSiteId { get; set; }
    public string Published { get; set; }
    public string? Updated { get; set; }
}

public class SiteRoot
{
    public SiteAggregates Counts { get; set; }
    public LocalSite LocalSite { get; set; }
    public LocalSiteRateLimit LocalSiteRateLimit { get; set; }
    public Site Site { get; set; }
    public Tagline[]? Taglines { get; set; }
}

public class Language
{
    public string Code { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SiteEnvelope
{
    
    public IList<int> DiscussionLanguages { get; set; }

    
    public FederatedInstances? FederatedInstances { get; set; }

    public MyUserInfo? MyUser { get; set; }
    public int Online { get; set; }

    public SiteRoot SiteView { get; set; }
    public IList<Tagline> Taglines { get; set; }

    public SiteRoot Site { get; set; }
    public IList<ModeratorRoot> Admins { get; set; }
    public IList<Language> AllLanguages { get; set; }

    public string Version { get; set; }
}

public class CommunityUser
{
    public Community Community { get; set; }
    public User Person { get; set; }
}

public class UserBlock
{
    public User Person { get; set; }
    public User Target { get; set; }
}

public class MyUserInfo
{
    public IList<CommunityUser> CommunityBlocks { get; set; }

    
    public IList<int> DiscussionLanguages { get; set; }

    public IList<CommunityUser> Follows { get; set; }

     public IList<UserSettings> LocalUserView { get; set; }
    public IList<CommunityUser> Moderates { get; set; }

    public IList<UserBlock> PersonBlocks { get; set; }
}

public class FederatedInstances
{
    public string[]? Allowed { get; set; }
    public string[]? Blocked { get; set; }
    public string[] Linked { get; set; }
}
