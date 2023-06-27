using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using Lemmy.Net.Client.Components;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;


namespace Lemmy.Net.Client.Models
{
    public static class HttpClientExtensions
    {
        //
        // //private static HttpClient http { get; set; }
        // static HttpClientExtensions()
        // {
        //     http = new HttpClient();
        // }
        
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
        public static async Task AddLemmyClient(this IServiceCollection services, string lemmyInstance, string username,
            string password, Func<string, Task<string>> retrieveToken = null, Action<string, string> saveToken = null,
            string apiVersion = "v3")
        {
            lemmyInstance = lemmyInstance.Replace("https://", "");
            lemmyInstance = lemmyInstance.Split("/").First();
            
            var uri = new Uri($"https://{lemmyInstance}/api/{apiVersion}/");
            services.AddLogging();
            services.AddHttpClient<ILemmyService, LemmyService>(client => { client.BaseAddress = uri; })
                .ConfigurePrimaryHttpMessageHandler(() =>
                    new CustomAuthenticationHandler(uri, username, password, retrieveToken, saveToken))
                
                .AddPolicyHandler((serviceProvider, request) =>
                {
                    return HttpPolicyExtensions
                        .HandleTransientHttpError()
                        .OrResult(x =>
                            x.StatusCode == HttpStatusCode.BadRequest && x.Content.Headers.ContentLength == 28)
                        .WaitAndRetryAsync(4, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
                });
        }

        public static string GetQueryString(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                query[property.Name] = value != null ? value.ToString() : string.Empty;
            }

            return query.ToString();
        }
    }
}