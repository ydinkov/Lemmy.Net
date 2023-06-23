using System.Net.Http.Json;
using System.Text.Json;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class UserComponent
{
    private readonly HttpClient _http;

    public UserComponent(HttpClient _http)
    {
        this._http = _http;
    }
    
    public async Task<LoginResponse> Login(Login login)
    {
        var res = await _http.PostAsync("/api/v3/user/login", JsonContent.Create(login));
        return await res.Content.ReadFromJsonAsync<LoginResponse>();
    }
    
    public async Task<LoginResponse> ChangePassword(ChangePassword newPassword)
    {
        var res = await _http.PostAsJsonAsync("/user/change_password", newPassword);
        return await res.Content.ReadFromJsonAsync<LoginResponse>();
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
}