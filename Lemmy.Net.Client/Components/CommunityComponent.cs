using System.Net.Http.Json;
using System.Text.Json;
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
        var res = await _http.PutAsJsonAsync("/community", edit,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>(options:Json.Options);
    }
    
    public async Task<CommunityEnvelope> Create(CreateCommunity create)
    {
        var res = await _http.PostAsJsonAsync("/community", create,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>(options:Json.Options);
    }
    
    public async Task<CommunityEnvelope> Follow(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/follow", new{community_id = communityId, follow=true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>(options:Json.Options);
    }
    
    public async Task<CommunityEnvelope> UnFollow(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/follow", new{community_id = communityId, follow=false},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>(options:Json.Options);
        
    }
    public async Task<bool> Delete(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/comment", new{community_id = communityId,delete= true},options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<CommunityEnvelope> Remove(int communityId, string reason)
    {
        var res = await _http.PostAsJsonAsync("/comment/remove",new{community_id = communityId,reason = reason, removed= true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>(options:Json.Options);
    }
    
    public async Task<CommunitiesEnvelope> List(CommunitiesRequest? q = null)
    {
        var query = q is null? string.Empty :  $"?{q.GetQueryString()}";   
        return await _http.GetFromJsonAsync<CommunitiesEnvelope>($"/community/list{query}");
    }
    
    public async Task<CommunityModEnvelope> CreateMod(int personId, int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/mod",
            new{person_id = personId,community_id = communityId, added = true },
            options:Json.Options);
        
        return await res.Content.ReadFromJsonAsync<CommunityModEnvelope>(options:Json.Options);
    }
    
    public async Task<UserRoot> BanUser(BanUser ban)
    {
        var res = await _http.PostAsJsonAsync("/community/ban", ban,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<UserRoot>(options:Json.Options);
    }
    
    
    public async Task<BlockCommunity> Block(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=true, community_id = communityId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<BlockCommunity>(options:Json.Options);
    }
    
    public async Task<BlockCommunity> UnBlock(int communityId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=false, community_id = communityId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<BlockCommunity>(options:Json.Options);
    }
    
    public async Task<CommunityEnvelope> Transfer(int communityId, int userId)
    {
        var res = await _http.PostAsJsonAsync("/community/transfer", new{user_id=userId, community_id = communityId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<CommunityEnvelope>(options:Json.Options);
    }
    
    public async Task<CommunityEnvelope?> Get(int? id = null, string? name = null) =>
        await _http.GetFromJsonAsync<CommunityEnvelope>($"/community?{new{id=id, name = name}.GetQueryString()}",options:Json.Options);
    
}