using System.Net.Http.Json;
using System.Text.Json;
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
        var res = await _http.PostAsJsonAsync("/comment/like", new {score=1, comment_id = commentId},options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Dislike(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment/like", new {score=-1, comment_id = commentId},options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Reset(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment/like", new {score=0, comment_id = commentId},options:Json.Options);
        return res.IsSuccessStatusCode;;
    }

    public async Task<bool> Edit(EditComment edit)
    {
        var res = await _http.PutAsJsonAsync("/comment", edit,options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    
    public async Task<CommentReportEnvelope> Report(int reportId, string reasonStr)
    {
        var res = await _http.PutAsJsonAsync("/comment/report", new{report_id = reportId, reason = reasonStr},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommentReportEnvelope>(options:Json.Options);
    }
    
    public async Task<CommentEnvelope> Save(int commentId)
    {
        var res = await _http.PutAsJsonAsync("/comment/save", new{comment_id = commentId,save = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommentEnvelope>(options:Json.Options);
    }
    
    public async Task<bool> Create(CreateComment createComment)
    {
        var res = await _http.PostAsJsonAsync("/comment", createComment,options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Delete(int commentId)
    {
        var res = await _http.PostAsJsonAsync("/comment", new{comment_id = commentId,delete= true},options:Json.Options);
        return res.IsSuccessStatusCode;
    }

    public async Task<CommentReportsEnvelope> Reports(CommentReportsRequest reports) =>
        await _http.GetFromJsonAsync<CommentReportsEnvelope>($"/comment/report/list?{reports.GetQueryString()}",options:Json.Options);
    
    public async Task<CommentReportEnvelope?> ResolveReport(int reportId)
    {
        var res = await _http.PutAsJsonAsync("/comment/report/resolve", new{report_id = reportId, resolved =true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommentReportEnvelope>(options:Json.Options);
    }
    
    public async Task<CommentEnvelope> MarkReplyAsRead(int replyId)
    {
        var res = await _http.PostAsJsonAsync("/comment/mark_as_read",new{comment_reply_id = replyId, read = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommentEnvelope>(options:Json.Options);
    }
    
    
    public async Task<CommentEnvelope> Remove(int commentId, string reason)
    {
        var res = await _http.PostAsJsonAsync("/comment/remove",new{comment_id = commentId, reason = reason, removed = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommentEnvelope>(options:Json.Options);
    }
    
    public async Task<CommentsEnvelope> List(CommentsRequest query)
    {
        var res = await _http.GetAsync($"/comment/list?{query.GetQueryString()}");
        try
        {
            var resp = await res.Content.ReadFromJsonAsync<CommentsEnvelope>(options:Json.Options);
            return resp;
        }
        catch(Exception e)
        {
            return null;
        }
    }
}