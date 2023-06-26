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

    public async Task<CommunityEnvelope> Edit(EditCommunity edit)
    {
        var res = await _http.PutAsJsonAsync("/community", edit);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>();
    }
    
    public async Task<CommunityEnvelope> Create(CreateCommunity create)
    {
        var res = await _http.PostAsJsonAsync("/community", create);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>();
    }
    
    public async Task<CommunityEnvelope> Follow(FollowCommunity follow)
    {
        var res = await _http.PostAsJsonAsync("/community/follow", follow);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>();
    }
    
    public async Task<bool> Delete(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/comment", new{community_id = communityId,delete= true});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<CommunityEnvelope> Remove(int communityId, string reason)
    {
        var res = await _http.PostAsJsonAsync("/comment/remove",new{community_id = communityId,reason = reason, removed= true});
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>();
    }
    
    public async Task<CommunitiesEnvelope> List(string? query = null)
    {
        var q = string.IsNullOrWhiteSpace(query) ? string.Empty : $"?{query}";
        var res = await _http.GetAsync($"/community/list{q}");
        return await res.Content.ReadFromJsonAsync<CommunitiesEnvelope>();
    }
    
    public async Task<CommunityModEnvelope> CreateMod(AddModToCommunity addMod)
    {
        var res = await _http.PostAsJsonAsync("/community/mod", addMod);
        return await res.Content.ReadFromJsonAsync<CommunityModEnvelope>();
    }
    
    public async Task<PersonRoot> BanUser(BanUser ban)
    {
        var res = await _http.PostAsJsonAsync("/community/ban", ban);
        return await res.Content.ReadFromJsonAsync<PersonRoot>();
    }
    
    
    public async Task<BlockCommunity> Block(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=true, community_id = communityId});
        return await res.Content.ReadFromJsonAsync<BlockCommunity>();
    }
    
    public async Task<BlockCommunity> UnBlock(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=false, community_id = communityId});
        return await res.Content.ReadFromJsonAsync<BlockCommunity>();
    }
    
    public async Task<CommunityEnvelope> Transfer(int communityId, int userId)
    {
        var res = await _http.PostAsJsonAsync("/community/transfer", new{user_id=userId, community_id = communityId});
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>();
    }
}