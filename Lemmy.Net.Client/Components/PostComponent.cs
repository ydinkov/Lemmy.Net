using System.Net.Http.Json;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class PostComponent
{
    
    private readonly HttpClient _http;

    public PostComponent(HttpClient _http)
    {
        this._http = _http;
    }
    
    public async Task<bool> Lock(int postId)
    {
        var res = await _http.PostAsync(new Uri("/post/lock"), JsonContent.Create(new {locked=true, post_id = postId}));
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to lock post: {res.StatusCode}");
        }
        return true;
    }
    
    public async Task<bool> Unlock(int postId)
    {
        var res = await _http.PostAsync(new Uri("/post/lock"), JsonContent.Create(new {locked=false, post_id = postId}));
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to unlock post: {res.StatusCode}");
        }
        return true;
    }
    
    
    public async Task<bool> Like(int postId)
    {
        var res = await _http.PostAsync("/post/like", JsonContent.Create(new {score=1, post_id = postId}));
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to lock post: {res.StatusCode}");
        }
        return true;
    }
    
    public async Task<bool> Dislike(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/like", new {score=-1, post_id = postId});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Reset(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/like", new {score=0, post_id = postId});
        return res.IsSuccessStatusCode;
    }
    public async Task<bool> Feature(int postId,string type)
    {
        var res = await _http.PostAsJsonAsync("/post/feature", new {feture_type=type,featured=true, post_id = postId});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Unfeature(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post/feature", new {feture_type=string.Empty,featured=false, post_id = postId});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Edit(EditPost edit)
    {
        var res = await _http.PutAsJsonAsync("/post", edit);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Report(int postId, string reason_for_report)
    {
        var res = await _http.PostAsJsonAsync("/post/report", new{postid = postId,reason = reason_for_report});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<PostEnvelope> Create(CreatePost createPost)
    {
        var res = await _http.PostAsJsonAsync("/post", createPost);
        return await res.Content.ReadFromJsonAsync<PostEnvelope>();
    }
    
    public async Task<PostEnvelope> Delete(int postId)
    {
        var res = await _http.PostAsJsonAsync("/post", new{post_id = postId, deleted =true});
        return await res.Content.ReadFromJsonAsync<PostEnvelope>();
    }
    
    public async Task<PostEnvelope> Get(int postId)
    {
        var res = await _http.GetAsync($"/post?id={postId}");
        return await res.Content.ReadFromJsonAsync<PostEnvelope>();
    }
    
    public async Task<PostsEnvelope> List(string? query = null)
    {
        var q = string.IsNullOrWhiteSpace(query) ? string.Empty : $"?{query}";
        var res = await _http.GetAsync($"/post/list{q}");
        return await res.Content.ReadFromJsonAsync<PostsEnvelope>();
    }
}