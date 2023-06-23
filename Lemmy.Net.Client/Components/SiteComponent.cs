using Lemmy.Net.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static Lemmy.Net.Client.Models.SiteModels;
using static System.Net.WebRequestMethods;

namespace Lemmy.Net.Client.Components
{

    public class SiteComponent
    {

        private readonly HttpClient _http;

        public SiteComponent(HttpClient _http)
        {
            this._http = _http;
        }

        public async Task<LoginResponse> CreateSite(CreateSite site)
        {
            var res = await _http.PostAsJsonAsync("/site", site);
            return await res.Content.ReadFromJsonAsync<LoginResponse>();
        }

    }
}
