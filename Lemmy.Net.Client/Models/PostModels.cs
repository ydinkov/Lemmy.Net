using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemmy.Net.Client.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Url { get; set; }
        public string Body { get; set; }
        public int CreatorId { get; set; }
        public int CommunityId { get; set; }
        public bool Removed { get; set; }
        public bool Locked { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool Nsfw { get; set; }
        public object EmbedTitle { get; set; }
        public object EmbedDescription { get; set; }
        public object EmbedVideoUrl { get; set; }
        public object ThumbnailUrl { get; set; }
        public string ApId { get; set; }
        public bool Local { get; set; }
        public int LanguageId { get; set; }
        public bool FeaturedCommunity { get; set; }
        public bool FeaturedLocal { get; set; }
    }

    public class Creator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public object Avatar { get; set; }
        public bool Banned { get; set; }
        public DateTime Published { get; set; }
        public object Updated { get; set; }
        public string ActorId { get; set; }
        public object Bio { get; set; }
        public bool Local { get; set; }
        public object Banner { get; set; }
        public bool Deleted { get; set; }
        public string InboxUrl { get; set; }
        public string SharedInboxUrl { get; set; }
        public object MatrixUserId { get; set; }
        public bool Admin { get; set; }
        public bool BotAccount { get; set; }
        public object BanExpires { get; set; }
        public int InstanceId { get; set; }
    }

   

    public class PostCounts
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int Comments { get; set; }
        public int Score { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime Published { get; set; }
        public DateTime NewestCommentTimeNecro { get; set; }
        public DateTime NewestCommentTime { get; set; }
        public bool FeaturedCommunity { get; set; }
        public bool FeaturedLocal { get; set; }
    }

    public class PostEnvelope
    {
        public Post Post { get; set; }
        public Creator Creator { get; set; }
        public Community Community { get; set; }
        public bool CreatorBannedFromCommunity { get; set; }
        public PostCounts Counts { get; set; }
        public string Subscribed { get; set; }
        public bool Saved { get; set; }
        public bool Read { get; set; }
        public bool CreatorBlocked { get; set; }
        public object MyVote { get; set; }
        public int UnreadComments { get; set; }
    }

}
