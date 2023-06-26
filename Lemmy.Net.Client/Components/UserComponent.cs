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
        await _http.GetFromJsonAsync<BannedUsersEnvelope>("/user/banned");
    
    public async Task<BannedUsersEnvelope> GetCaptcha() =>
        await _http.GetFromJsonAsync<BannedUsersEnvelope>("/user/get_captcha");
        
    public async Task<LoginEnvelope> Login(Login login)
    {
        var res = await _http.PostAsync("/api/v3/user/login", JsonContent.Create(login));
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>();
    }
    


    public async Task<LoginEnvelope> ChangePassword(string password)
    {
        var res = await _http.PostAsJsonAsync("/user/delete", new {password = password});
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>();
    }

    public async Task<PersonRoot> Ban(int userId, bool deleteData = true)
    {
        var res = await _http.PostAsJsonAsync("/user/ban", new{ban =true,user_id = userId,remove_data=deleteData});
        return await res.Content.ReadFromJsonAsync<PersonRoot>();
    }
    
    public async Task<BlockUser> Block(int userId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=true, person_id = userId});
        return await res.Content.ReadFromJsonAsync<BlockUser>();
    }
    
    public async Task<BlockUser> UnBlock(int userId)
    {
        var res = await _http.PostAsJsonAsync("/community/block", new{block=false, person_id = userId});
        return await res.Content.ReadFromJsonAsync<BlockUser>();
    }
  
    public async Task<DeleteAccountResponse> Delete(string password)
    {
        var res = await _http.PostAsJsonAsync("/user/delete_account", new { password = password});
        return await res.Content.ReadFromJsonAsync<DeleteAccountResponse>();
    }

    public async Task<UserDetails> GetDetails(GetUserDetails details)=> 
        await _http.GetFromJsonAsync<UserDetails>($"/user?{details.GetQueryString()}");


    public async Task<UserMentionsEnvelope> GetMentions(GetUserMentions mentions)=> 
        await _http.GetFromJsonAsync<UserMentionsEnvelope>($"/user/mention?{mentions.GetQueryString()}");

    public async Task<RepliesEnvelope> GetReplies(GetReplies replies)=> 
        await _http.GetFromJsonAsync<RepliesEnvelope>($"/user/reply?{replies.GetQueryString()}");
        

    public async Task<ReportCount> GetReportCount(int communityId) =>
        await _http.GetFromJsonAsync<ReportCount>($"/user/report_count?community_id={communityId}");
    
    
    public async Task<UnreadCount> GetUnread() =>
        await _http.GetFromJsonAsync<UnreadCount>($"/user/unread_count");

    public async Task<SiteEnvelope> LeaveAdmin()
    {
        var res = await _http.PostAsJsonAsync<Dictionary<string,string>>("/user/leave_admin",new());
        return await res.Content.ReadFromJsonAsync<SiteEnvelope>();
    }
    
    public async Task<RepliesEnvelope> MarkAllAsReaddw()
    {
        var res = await _http.PostAsJsonAsync<Dictionary<string,string>>("/user/mark_all_as_read",new());
        return await res.Content.ReadFromJsonAsync<RepliesEnvelope>();
    }

    public async Task<bool> PasswordReset(string email)
    {
        var res = await _http.PostAsJsonAsync("/user/password_reset",new{email=email});
        return res.IsSuccessStatusCode;
    }
    
    public async Task<LoginEnvelope> ChangePassword(ChangePassword newPassword)
    {
        var res = await _http.PostAsJsonAsync("/user/change_password", newPassword);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>();
    }

    
    
    public async Task<UserMentionEnvelope> MarkMentionAsRead(int personMentionId)
    {
        var res = await _http.PostAsJsonAsync("/user/mention/mark_as_read",new{person_mention_id=personMentionId, read = true});
        return await res.Content.ReadFromJsonAsync<UserMentionEnvelope>();
    }

    public async Task<LoginEnvelope> Register(RegistrationRequest registration)
    {
        var res = await _http.PostAsJsonAsync("/user/register",registration);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>();
    }
    
    public async Task<LoginEnvelope> SaveSetting(SaveUserSettingsRequest req)
    {
        var res = await _http.PutAsJsonAsync("/user/save_user_settings", req);
        return await res.Content.ReadFromJsonAsync<LoginEnvelope>();
    }

    public async Task<bool> VerifyEmail(string token)
    {
        var res = await _http.PostAsJsonAsync("/user/verify_email",new{token = token});
        return res.IsSuccessStatusCode;
    }

    

}
