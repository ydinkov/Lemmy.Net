using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class PostComponent
{
    
    private readonly HttpClient _http;

    public PostComponent(HttpClient _http)
    {
        this._http = _http;
    }
    
    public async Task<PostReportEnvelope> ResolveReport(int reportId)
    {
        var res = await _http.PutAsJsonAsync("/post/report/resolve", new{report_id = reportId, resolved =true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostReportEnvelope>(options:Json.Options);
    }

    
    public async Task<bool> Lock(int postId)
    {
        var res = await _http.PostAsync(new Uri("/post/lock"), JsonContent.Create(new {locked=true, post_id = postId},options:Json.Options));
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to lock post: {res.StatusCode}");
        }
        return true;
    }
    
    public async Task<bool> Unlock(int postId)
    {
        var res = await _http.PostAsync(new Uri("/post/lock"), JsonContent.Create(new {locked=false, post_id = postId},options:Json.Options));
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to unlock post: {res.StatusCode}");
        }
        return true;
    }
    
    
    public async Task<bool> Like(int postId)
    {
        var res = await _http.PostAsync("/post/like", JsonContent.Create(new {score=1, post_id = postId},options:Json.Options));
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to lock post: {res.StatusCode}");
        }
        return true;
    }
    
    public async Task<bool> Dislike(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/like", new {score=-1, post_id = postId},options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Reset(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/like", new {score=0, post_id = postId},options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    public async Task<PostEnvelope> Feature(int postId,string type)
    {
        var res = await _http.PostAsJsonAsync("/post/feature", new {feture_type=type,featured=true, post_id = postId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    
    public async Task<PostEnvelope> Unfeature(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/feature", new {feture_type=string.Empty,featured=false, post_id = postId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    
    public async Task<PostEnvelope> Edit(EditPost edit)
    {
        var res = await _http.PutAsJsonAsync("/post", edit,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    
    public async Task<PostReportEnvelope?> Report(int postId, string reason_for_report)
    {
        var res = await _http.PostAsJsonAsync("/post/report", new{postid = postId,reason = reason_for_report},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostReportEnvelope>(options:Json.Options);
    }
    
    public async Task<PostEnvelope> Create(CreatePost createPost)
    {
        var res = await _http.PostAsJsonAsync("/post", createPost,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    
    //public async Task<PostEnvelope> Delete(int postId)
    //{
    //    var res = await _http.PostAsJsonAsync("/post/delete", new{post_id = postId, deleted =true},options:Json.Options);
    //    return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    //}
    
    public async Task<PostEnvelope> Remove(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/remove", new{post_id = postId, removed =true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    
    public async Task<PostEnvelope> Get(int postId)
    {
        var res = await _http.GetAsync($"/post?id={postId}");
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    
    public async Task<PostsEnvelope> List(string? query = null)
    {
        var q = string.IsNullOrWhiteSpace(query) ? string.Empty : $"?{query}";
        var res = await _http.GetAsync($"/post/list{q}");
        return await res.Content.ReadFromJsonAsync<PostsEnvelope>(options:Json.Options);
    }
    
    public async Task<SiteMetadataEnvelope> GetMetadata(Uri url) =>
        await _http.GetFromJsonAsync<SiteMetadataEnvelope>($"/post/site_metadata?url={HttpUtility.UrlEncode(url.ToString())}",options:Json.Options);

    
    public async Task<PostReportsEnvelope> Reports(PostReportsRequest? reports = null) =>
        await _http.GetFromJsonAsync<PostReportsEnvelope>($"/post/report/list?{reports?.GetQueryString()??String.Empty}",options:Json.Options);
    
    public async Task<PostEnvelope> MarkAsRead(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/mark_as_read", new{post_id = postId, read =true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }
    

    public async Task<PostEnvelope> Save(int postId)
    {
        var res = await _http.PutAsJsonAsync("/post/save", new{post_id = postId,save = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>(options:Json.Options);
    }

    


}