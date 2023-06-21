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
        if (!res.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Failed to log in: {res.StatusCode}");
        }
        return JsonSerializer.Deserialize<LoginResponse>(await res.Content.ReadAsStringAsync());
    }
}