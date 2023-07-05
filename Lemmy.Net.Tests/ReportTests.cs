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

    
    [Fact(Skip = "")]
    public async Task GetCommentReports()
    {
        var commentReports = await _lemmy.Comment.Reports(new());
        commentReports.CommentReports.Should().NotBeNull();
    }
    
    [Fact(Skip = "")]
    public async Task GetPMReports()
    {
        var commentReports = await _lemmy.PrivateMessage.Reports(new());
        commentReports.PrivateMessageReports.Should().NotBeNull();
    }
    
    [Fact(Skip = "")]
    public async Task ReportPostTest()
    {
        var postReported = await _lemmy.Post.Report(0,"test");
        postReported.Should().NotBeNull();
    }
    
    [Fact(Skip = "")]
    public async Task ReportComment()
    {
        var commentReported = await _lemmy.Comment.Report(0,"test");
        commentReported.Should().NotBeNull();
    }
    [Fact(Skip = "")]
    public async Task ReportPM()
    {
        var commentReported = await _lemmy.PrivateMessage.Report(0,"test");
        commentReported.Should().NotBeNull();
    }
    [Fact(Skip = "")]
    public async Task ResolvePostReport()
    {
        var postReported = await _lemmy.Post.ResolveReport(0);
        postReported.Should().NotBeNull();
    }
    [Fact(Skip = "")]
    public async Task ResolveCommentReport()
    {
        var commentReported = await _lemmy.Comment.ResolveReport(0);
        commentReported.Should().NotBeNull();
    }
    [Fact(Skip = "")]
    public async Task ResolvePMReport()
    {
        var commentReported = await _lemmy.PrivateMessage.ResolveReport(0);
        commentReported.Should().NotBeNull();
    }

}