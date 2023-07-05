using System.Net.Http.Json;
using System.Text.Json;
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

    public async Task<PrivateMessageEnvelope> Create(int recipientId, string content)
    {
        var res = await _http.PostAsJsonAsync("/private_message", new{recipient_id= recipientId, content = content},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PrivateMessageEnvelope>(options:Json.Options);
    }

    public async Task<PrivateMessageReportEnvelope> Report(int privateMessageId, string reasonStr)
    {
        var res = await _http.PostAsJsonAsync("/private_message/report", new { private_message_id = privateMessageId, reason = reasonStr},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PrivateMessageReportEnvelope>(options:Json.Options);
    }


    public async Task<PrivateMessageRoot> Delete(int privateMessageId)
    {
        var res = await _http.PostAsJsonAsync("/private_message/delete", new { private_message_id = privateMessageId, deleted = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PrivateMessageRoot>(options:Json.Options);
    }


    public async Task<PrivateMessageRoot> Edit(int privateMessageId, string content)
    {
        var res = await _http.PostAsJsonAsync("/private_message", new { private_message_id = privateMessageId, content = content},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PrivateMessageRoot>(options:Json.Options);
    }

    public async Task<PrivateMessagesEnvelope> List(PrivateMessagesRequest? req = null)
    {
        var query = req == null? string.Empty :  $"?{req.GetQueryString()}";
        var res = await _http.GetFromJsonAsync<PrivateMessagesEnvelope>($"/private_message/list{query}",options:Json.Options);
        return res;
    }

    public async Task<PrivateMessageReportsEnvelope> ListReports(int limit = 10, int page = 0, bool unresolvedOnly = false)
    {
        var res = await _http.GetFromJsonAsync<PrivateMessageReportsEnvelope>($"/private_message/report/list?limit={limit}&page={0}&unresolved_only={unresolvedOnly}",options:Json.Options);
        return res;
    }

    public async Task<PrivateMessageEnvelope> MarkAsRead(int id)
    {
        var res = await _http.PostAsJsonAsync($"/private_message/mark_as_read", new {private_message_id = id, read = true},options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PrivateMessageEnvelope>(options:Json.Options);
    }
    public async Task<PrivateMessageReportEnvelope> ResolveReport(int reportId)
    {
        var res = await _http.PutAsJsonAsync("/private_message/report/resolve", new { report_id = reportId, resolved= true },options:Json.Options);
        return await res.Content.ReadFromJsonAsync<PrivateMessageReportEnvelope>(options:Json.Options);
    }

    public async Task<PrivateMessageReportsEnvelope> Reports(PrivateMessageReportsRequest reports) =>
        await _http.GetFromJsonAsync<PrivateMessageReportsEnvelope>($"/private_message/report/list?{reports.GetQueryString()}",options:Json.Options);




}