using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class PrivateMessageComponent
{
    private readonly HttpClient _http;

    public PrivateMessageComponent(HttpClient _http)
    {
        this._http = _http;
    }

    public async Task<PrivateMessageCreated> Create(string recipient, string content)
    {
        var res = await _http.PostAsJsonAsync("/private_message", new{recipient= recipient, content = content});
        return await res.Content.ReadFromJsonAsync<PrivateMessageCreated>();
    }

    public async Task<AdminsEnvelope> ApproveRegistration(ApproveRegistration admin)
    {
        var res = await _http.PutAsJsonAsync("/admin/registration_application/approve", admin);
        return await res.Content.ReadFromJsonAsync<AdminsEnvelope>();
    }

    public class RegistrationApplication
    {
        [JsonPropertyName("admin_id")] public int AdminId { get; private set; }
        public string Answer { get; private set; } = string.Empty;
        [JsonPropertyName("deny_reason")] public string? DenyReason { get; private set; }
        public int Id { get; private set; }
        [JsonPropertyName("local_user_id")] public int LocalUserId { get; private set; }
        public string Published { get; private set; } = string.Empty;
    }
}