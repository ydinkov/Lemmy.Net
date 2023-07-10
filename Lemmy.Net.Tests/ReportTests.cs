using System.Configuration;
using FluentAssertions;
using Lemmy.Net.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nibblebit.Lemmy.Tests;


public class ReportTests : AbstractTest
{
    [Fact(Skip = "")]
    public async Task GetPostReports()
    {
        var postReports = await _lemmy.Post.Reports(new());
        postReports.PostReports.Should().NotBeNull();
    }

    
    
    public async Task GetCommentReports()
    {
        var commentReports = await _lemmy.Comment.Reports(new());
        commentReports.CommentReports.Should().NotBeNull();
    }
    
    //[Fact(Skip = "")]
    //public async Task GetPMReports()
    //{
    //    var commentReports = await _lemmy.PrivateMessage.Reports(new());
    //    commentReports.PrivateMessageReports.Should().NotBeNull();
    //}
    [Fact]
    public async Task ReportPostTest()
    {
        var communities = await _lemmy.Community.List();
        var botspam = communities.Communities.Single(x => x.Community.Name == "botspam");

        var post = new CreatePost
        {
            Name = "unitTest spam",
            CommunityId = botspam.Community.Id
        };
        var postCreated = await _lemmy.Post.Create(post);
        var postReported = await _lemmy.Post.Report(postCreated.PostView.Post.Id,"test");
        var postResolved = await _lemmy.Post.ResolveReport(postReported.PostReportView.PostReport.Id);
        postResolved.Should().NotBeNull();
        
        
        //Cleanup
        var postDeleted = await _lemmy.Post.Remove(postCreated.PostView.Post.Id);
        postDeleted.Should().NotBeNull();
    }
    
   //[Fact(Skip = "")]
   //public async Task ReportComment()
   //{
   //    var commentReported = await _lemmy.Comment.Report(0,"test");
   //    commentReported.Should().NotBeNull();
   //}
    //[Fact(Skip = "")]
    //public async Task ReportPM()
    //{
    //    var commentReported = await _lemmy.PrivateMessage.Report(0,"test");
    //    commentReported.Should().NotBeNull();
    //}
    //[Fact(Skip = "")]
    public async Task ResolvePostReport()
    {
        var postReported = await _lemmy.Post.ResolveReport(0);
        postReported.Should().NotBeNull();
    }
    //[Fact(Skip = "")]
    public async Task ResolveCommentReport()
    {
        var commentReported = await _lemmy.Comment.ResolveReport(0);
        commentReported.Should().NotBeNull();
    }
    //[Fact(Skip = "")]
    public async Task ResolvePMReport()
    {
        var commentReported = await _lemmy.PrivateMessage.ResolveReport(0);
        commentReported.Should().NotBeNull();
    }

}