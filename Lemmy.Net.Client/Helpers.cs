using Lemmy.Net.Client;
using Microsoft.Extensions.DependencyInjection;


namespace Lemmy.Net.Client.Models
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Adds an HTTP client for Lemmy service with optional JWT token retrieval and saving functionality.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the service to.</param>
        /// <param name="lemmyInstanceBaseUri">The base URI of the Lemmy instance.</param>
        /// <param name="username">The username for the Lemmy service.</param>
        /// <param name="password">The password for the Lemmy service.</param>
        /// <param name="retrieveToken">A function to retrieve the JWT token for a username. 
        /// If the function returns null, a login request will be made to retrieve the token.
        /// This parameter is optional and can be null.</param>
        /// <param name="saveToken">An action to save the JWT token for a username after it's retrieved from a login request.
        /// This parameter is optional and can be null.</param>
        public static void AddLemmyClient(this IServiceCollection services, Uri lemmyInstanceBaseUri, string username, string password, Func<string, Task<string>> retrieveToken = null, Action<string, string> saveToken = null)
        {
            services.AddHttpClient<ILemmyService, LemmyService>(client =>
            {
                client.BaseAddress = lemmyInstanceBaseUri;
            })
            .ConfigurePrimaryHttpMessageHandler(() => new CustomAuthenticationHandler(username, password, retrieveToken, saveToken));
        }
    }
}