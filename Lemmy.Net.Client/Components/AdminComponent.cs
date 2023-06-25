using System.Net.Http.Json;
using System.Text.Json.Serialization;
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
        var res = await _http.PostAsJsonAsync("/admin", admin);
        return await res.Content.ReadFromJsonAsync<AdminsEnvelope>();
    }

    public async Task<AdminsEnvelope> ApproveRegistration(ApproveRegistration admin)
    {
        var res = await _http.PutAsJsonAsync("/admin/registration_application/approve", admin);
        return await res.Content.ReadFromJsonAsync<AdminsEnvelope>();
    }

    
   
    public async Task<UnreadRegistrationApplicationCount> GetUnreadRegistration() =>
        await _http.GetFromJsonAsync<UnreadRegistrationApplicationCount>("/admin/registration_application/count");


  
    
}