using System.Net.Http.Json;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class CommentComponent
{
    
    private readonly HttpClient _http;

    public CommentComponent(HttpClient _http)
    {
        this._http = _http;
    }
    public async Task<bool> Like(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment/like", new {score=1, comment_id = commentId});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Dislike(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment/like", new {score=-1, comment_id = commentId});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Reset(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment/like", new {score=0, comment_id = commentId});
        return res.IsSuccessStatusCode;;
    }

    public async Task<bool> Edit(EditComment edit)
    {
        var res = await _http.PutAsJsonAsync("/comment", edit);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Report(int postId, string reason_for_report)
    {
        var res = await _http.PostAsJsonAsync("/post/report", new{post_id = postId,reason = reason_for_report});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<CommentReportEnvelope> Report(int reportId)
    {
        var res = await _http.PutAsJsonAsync("/comment/report/resolve", new{report_id = reportId,resolved = true});
        return await res.Content.ReadFromJsonAsync<CommentReportEnvelope>();
    }
    
    public async Task<bool> Create(CreateComment createComment)
    {
        var res = await _http.PostAsJsonAsync("/comment", createComment);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Delete(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment", new{comment_id = commentId,delete= true});
        return res.IsSuccessStatusCode;
    }

    public async Task<CommentReportsEnvelope> Reports(CommentReportsRequest reports) =>
        await _http.GetFromJsonAsync<CommentReportsEnvelope>($"/comment/report/list?{reports.GetQueryString()}");
    
    public async Task<CommentEnvelope> MarkReplyAsRead(int replyId)
    {
        var res = await _http.PostAsJsonAsync("/comment/mark_as_read",new{comment_reply_id = replyId, read = true});
        return await res.Content.ReadFromJsonAsync<CommentEnvelope>();
    }
    
    
    public async Task<CommentEnvelope> Remove(int commentId, string reason)
    {
        var res = await _http.PostAsJsonAsync("/comment/remove",new{comment_id = commentId, reason = reason, removed = true});
        return await res.Content.ReadFromJsonAsync<CommentEnvelope>();
    }
    
    public async Task<CommentsEnvelope> List(string query)
    {
        var q = string.IsNullOrWhiteSpace(query) ? string.Empty : $"?{query}";
        var res = await _http.GetAsync($"/comment/list{q}");
        try
        {
            return await res.Content.ReadFromJsonAsync<CommentsEnvelope>();
        }
        catch(Exception e)
        {
            return null;
        }
    }
}