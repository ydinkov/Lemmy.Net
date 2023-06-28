using System.Net.Http.Json;
using System.Text.Json;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class AdminComponent
{
    private readonly HttpClient _http;

    public AdminComponent(HttpClient _http)
    {
        this._http = _http;
    }
    public async Task<AdminsEnvelope> CreateAdmin(AddAdmin admin)
    {
        var res = await _http.PostAsJsonAsync("/admin", admin,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<AdminsEnvelope>(options:Json.Options);
    }

    public async Task<AdminsEnvelope> ApproveRegistration(ApproveRegistration admin)
    {
        var res = await _http.PutAsJsonAsync("/admin/registration_application/approve", admin,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<AdminsEnvelope>(options:Json.Options);
    }
    
    
    public async Task<bool> PurgeComment(int commentId, string reason)
    {
        var res = await _http.PutAsJsonAsync("/admin/purge/comment",new{comment_id = commentId, reason = reason},options:Json.Options);
        return (await res.Content.ReadFromJsonAsync<dynamic>(options:Json.Options)).success;
    }
    
    public async Task<bool> PurgeCommunity(int communityId, string reason)
    {
        var res = await _http.PutAsJsonAsync("/admin/purge/community",new{community_id = communityId, reason = reason},options:Json.Options);
        return (await res.Content.ReadFromJsonAsync<dynamic>(options:Json.Options)).success;
    }
    
    public async Task<bool> PurgeUser(int userId, string reason)
    {
        var res = await _http.PutAsJsonAsync("/admin/purge/person",new{person_id = userId, reason = reason},options:Json.Options);
        return (await res.Content.ReadFromJsonAsync<dynamic>(options:Json.Options)).success;
    }
    
    public async Task<bool> PurgePost(int postId, string reason)
    {
        var res = await _http.PutAsJsonAsync("/admin/purge/post",new{post_id = postId, reason = reason},options:Json.Options);
        return (await res.Content.ReadFromJsonAsync<dynamic>(options:Json.Options)).success;
    }
    
    
    public async Task<UnreadRegistrationApplicationCount> GetUnreadRegistration() =>
        await _http.GetFromJsonAsync<UnreadRegistrationApplicationCount>("/admin/registration_application/count",options:Json.Options);


    public async Task<RegistrationApplicationsEnvelope> GetApplications(RegistrationApplicationsRequest applications) =>
        await _http.GetFromJsonAsync<RegistrationApplicationsEnvelope>($"/admin/registration_application/list?{applications.GetQueryString()}",options:Json.Options);



    
}