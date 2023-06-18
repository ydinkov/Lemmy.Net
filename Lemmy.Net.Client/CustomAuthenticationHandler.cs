using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lemmy.Net.Client { 
    public class CustomAuthenticationHandler : HttpClientHandler
    {
        private readonly Uri _lemmyInstanceBaseUri;
        private readonly string _username;
        private readonly string _password;
        private readonly Func<string, Task<string>> _retrieveToken;
        private readonly Action<string, string> _saveToken;

        public CustomAuthenticationHandler(Uri lemmyInstanceBaseUri, string username, string password, Func<string, Task<string>> retrieveToken = null, Action<string, string> saveToken = null)
        {
            _lemmyInstanceBaseUri = lemmyInstanceBaseUri;
            _username = username;
            _password = password;
            _retrieveToken = retrieveToken;
            _saveToken = saveToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwtToken = await _retrieveToken(_username);

            if (string.IsNullOrWhiteSpace(jwtToken))
            {

                var url = new UriBuilder(_lemmyInstanceBaseUri) { Path = "/api/v3/user/login" }.ToString();
                var obj = JsonSerializer.Serialize(new { username_or_email = _username, password = _password });
                var content = new StringContent(obj, Encoding.UTF8, "application/json");
                var loginResponse = await base.SendAsync(new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                }, cancellationToken);

                if (!loginResponse.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Failed to log in: {loginResponse.StatusCode}");
                }

                var loginContent = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(await loginResponse.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                jwtToken = loginContent["jwt"].ToString();

                // Save the token
                if (_saveToken != null)
                {
                    _saveToken(_username, jwtToken);
                }
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }


}
