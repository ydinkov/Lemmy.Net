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

public class ModeratorRoot
{
    public User Moderator { get; set; }
    public Community Community { get; set; }
}