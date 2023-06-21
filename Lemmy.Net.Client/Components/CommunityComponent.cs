using System.Net.Http.Json;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class CommunityComponent
{
    
    private readonly HttpClient _http;

    public CommunityComponent(HttpClient _http)
    {
        this._http = _http;
    }
   

    public async Task<bool> Edit(EditCommunity edit)
    {
        var res = await _http.PutAsJsonAsync("/community", edit);
        return res.IsSuccessStatusCode;
    }

    
    public async Task<bool> Create(CreateCommunity create)
    {
        var res = await _http.PostAsJsonAsync("/community", create);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> Delete(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/comment", new{community_id = communityId,delete= true});
        return res.IsSuccessStatusCode;
    }
    public async Task<CommunityEnvelope> List(string? query = null)
    {
        var q = string.IsNullOrWhiteSpace(query) ? string.Empty : $"?{query}";
        var res = await _http.GetAsync($"/community/list{q}");
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>();
    }
}