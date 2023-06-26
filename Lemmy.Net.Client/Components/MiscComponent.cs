using System.Net.Http.Json;
using Lemmy.Net.Client.Models;

namespace Lemmy.Net.Client.Components;

public class MiscComponent
{
    
    
    private readonly HttpClient _http;

    public MiscComponent(HttpClient _http)
    {
        this._http = _http;
    }
    public async Task<SearchEnvelope> GetReportCount(SearchRequest search) =>
        await _http.GetFromJsonAsync<SearchEnvelope>($"/user/report_count?{search.GetQueryString()}");


}