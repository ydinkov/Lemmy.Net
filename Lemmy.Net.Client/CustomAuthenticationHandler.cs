using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Lemmy.Net.Client { 
    public class CustomAuthenticationHandler : HttpClientHandler
    {
        private readonly Uri _lemmyInstanceBaseUri;
        private readonly string _username;
        private readonly string _password;
        private readonly Func<string, Task<string>> _retrieveToken;
        private readonly Action<string, string> _saveToken;
        private readonly string _defaultVersion;

        public CustomAuthenticationHandler(Uri lemmyInstanceBaseUri, string username, string password, Func<string, Task<string>> retrieveToken = null, Action<string, string> saveToken = null,string defaultVersion="v3")
        {
            _lemmyInstanceBaseUri = lemmyInstanceBaseUri;
            _username = username;
            _password = password;
            _retrieveToken = retrieveToken;
            _saveToken = saveToken;
            _defaultVersion = defaultVersion;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwtToken = await _retrieveToken(_username);
            
            
            var defaultPath = $"/api/{_defaultVersion}";
            // Retry policies are messing with this
            //I don't know what I'm doing with
            if (!request.RequestUri.ToString().Contains(defaultPath))
            {
                var builder = new UriBuilder(request.RequestUri)
                {
                    Path =  $"{defaultPath}{request.RequestUri.AbsolutePath}"
                };
                request.RequestUri = builder.Uri;
            }

            //return await base.SendAsync(request, cancellationToken);

            if (string.IsNullOrWhiteSpace(jwtToken))
            {

                var urib = new UriBuilder(_lemmyInstanceBaseUri);
                urib.Path += "user/login";
                var uri = urib.ToString();
                
                var obj = JsonSerializer.Serialize(new { username_or_email = _username, password = _password });
                var content = new StringContent(obj, Encoding.UTF8, "application/json");
                var loginResponse = await base.SendAsync(new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = content
                }, cancellationToken);

                if (!loginResponse.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Failed to log in: {loginResponse.StatusCode}");
                }

                var loginContent = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(await loginResponse.Content.ReadAsStreamAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken);
                jwtToken = loginContent["jwt"].ToString();

                // Save the token
                if (_saveToken != null)
                {
                    _saveToken(_username, jwtToken);
                }
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            //I really don't understand why the api want's the following, but okay.
            if (request.Method == HttpMethod.Post)
            {
                //interscept the request object
                var str = await request.Content.ReadAsStringAsync(cancellationToken);
                var proxy = JsonSerializer.Deserialize<Dictionary<string,object>>(str);
                //Add the token to an auth property
                proxy["auth"] = jwtToken;
                request.Content = JsonContent.Create(proxy);
            }
            
          var res = await base.SendAsync(request, cancellationToken);

           return res.IsSuccessStatusCode ? res
               : throw new HttpRequestException((await res.Content.ReadAsStringAsync(cancellationToken)), null,
                   res.StatusCode);
 
            
    
        }
    }

    
    
}
