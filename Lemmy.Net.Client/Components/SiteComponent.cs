using Lemmy.Net.Client.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Lemmy.Net.Client.Components
{
    public class SiteComponent
    {
        private readonly HttpClient _http;

        public SiteComponent(HttpClient _http)
        {
            this._http = _http;
        }

        public async Task<SiteEnvelope> CreateSite(CreateSite site)
        {
            var res = await _http.PostAsJsonAsync("/site", site,options:Json.Options);
            return await res.Content.ReadFromJsonAsync<SiteEnvelope>(options:Json.Options);
        }
        public async Task<SiteEnvelope> GetSite() =>
            await _http.GetFromJsonAsync<SiteEnvelope>("/site",options:Json.Options);


        public async Task<SiteEnvelope> EditSite(EditSite site)
        {
            var res = await _http.PutAsJsonAsync("/site", site,options:Json.Options);
            return await res.Content.ReadFromJsonAsync<SiteEnvelope>(options:Json.Options);
        }
        
        public async Task<SiteMetadataEnvelope> GetMetadata() =>
            await _http.GetFromJsonAsync<SiteMetadataEnvelope>($"/site/metadata",options:Json.Options);

    }
}