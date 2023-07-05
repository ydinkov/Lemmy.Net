using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class UserComponent
{
    private readonly HttpClient _http;

    public UserComponent(HttpClient _http)
    {
        this._http = _http;
    }
    
    public async Task<BannedUsersEnvelope> GetBanned() =>
        await _http.GetFromJsonAsync<BannedUsersEnvelope>("/user/banned",options:Json.Options);
    
    public async Task<BannedUsersEnvelope> GetCaptcha() =>
        await _http.GetFromJsonAsync<BannedUsersEnvelope>("/user/get_captcha",options:Json.Options);
        
    public async Task<LoginEnvelope> LoginAsync(string username, string password, CancellationToken c = default)
    {
        var res = await _http.PostAsJsonAsync("/api/v3/user/login", new{username_or_email = username, password = password},options:Json.Options,c);
        try
        {
            var res2 = await res.Content.ReadFromJsonAsync<LoginEnvelope>(cancellationToken: c,options:Json.Options);
            return res2;
        }
        catch(Exception e)
        {
            return null;
        }
    }
    


    public async Task<LoginEnvelope> ChangePassword(string password)
    {
        var res = await _http.PostAsJsonAsync("/user/delete", new {password = password},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>(options:Json.Options);
    }

    public async Task<UserRoot> Ban(int userId, bool deleteData = true)
    {
        var res = await _http.PostAsJsonAsync("/user/ban", new{ban =true,user_id = userId,remove_data=deleteData},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<UserRoot>(options:Json.Options);
    }
    
    public async Task<BlockUser> Block(int userId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=true, person_id = userId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<BlockUser>(options:Json.Options);
    }
    
    public async Task<BlockUser> UnBlock(int userId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=false, person_id = userId},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<BlockUser>(options:Json.Options);
    }
  
    public async Task<DeleteAccountResponse> Delete(string password)
    {
        var res = await _http.PostAsJsonAsync("/user/delete_account", new { password = password},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<DeleteAccountResponse>(options:Json.Options);
    }

    public async Task<UserDetailsEnvelope> GetDetails(UserDetailsRequest detailsRequest)=> 
        await _http.GetFromJsonAsync<UserDetailsEnvelope>($"/user?{detailsRequest.GetQueryString()}",options:Json.Options);


    public async Task<UserMentionsEnvelope> GetMentions(GetUserMentions mentions)=> 
        await _http.GetFromJsonAsync<UserMentionsEnvelope>($"/user/mention?{mentions.GetQueryString()}",options:Json.Options);

    public async Task<RepliesEnvelope> GetReplies(GetReplies replies)=> 
        await _http.GetFromJsonAsync<RepliesEnvelope>($"/user/reply?{replies.GetQueryString()}",options:Json.Options);
        


    public async Task<UnreadCount> GetUnread() =>
        await _http.GetFromJsonAsync<UnreadCount>($"/user/unread_count",options:Json.Options);

    public async Task<SiteEnvelope> LeaveAdmin()
    {
        var res = await _http.PostAsJsonAsync<Dictionary<string,string>>("/user/leave_admin",new(),options:Json.Options);
        return await res.Content.ReadFromJsonAsync<SiteEnvelope>(options:Json.Options);
    }
    
    public async Task<RepliesEnvelope> MarkAllAsReaddw()
    {
        var res = await _http.PostAsJsonAsync<Dictionary<string,string>>("/user/mark_all_as_read",new(),options:Json.Options);
        return await res.Content.ReadFromJsonAsync<RepliesEnvelope>(options:Json.Options);
    }

    public async Task<bool> PasswordReset(string email)
    {
        var res = await _http.PostAsJsonAsync("/user/password_reset",new{email=email},options:Json.Options);
        return res.IsSuccessStatusCode;
    }
    
    public async Task<LoginEnvelope> ChangePassword(ChangePassword newPassword)
    {
        var res = await _http.PostAsJsonAsync("/user/change_password", newPassword,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>(options:Json.Options);
    }

    
    
    public async Task<UserMentionEnvelope> MarkMentionAsRead(int personMentionId)
    {
        var res = await _http.PostAsJsonAsync("/user/mention/mark_as_read",new{person_mention_id=personMentionId, read = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<UserMentionEnvelope>(options:Json.Options);
    }

    public async Task<LoginEnvelope> Register(RegistrationRequest registration)
    {
        var res = await _http.PostAsJsonAsync("/user/register",registration,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>(options:Json.Options);
    }
    
    public async Task<LoginEnvelope> SaveSetting(SaveUserSettingsRequest req)
    {
        var res = await _http.PutAsJsonAsync("/user/save_user_settings", req,options:Json.Options);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>(options:Json.Options);
    }

    public async Task<bool> VerifyEmail(string token)
    {
        var res = await _http.PostAsJsonAsync("/user/verify_email",new{token = token},options:Json.Options);
        return res.IsSuccessStatusCode;
    }

    public async Task<ReportCount?> GetReportCount(int? communityId = null)
    {
        var query = communityId is null? string.Empty :  $"?{new { community_id = communityId }}";
        return await _http.GetFromJsonAsync<ReportCount>($"/user/report_count{query}",options:Json.Options);
    }
    

}
