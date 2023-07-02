using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Microsoft.Extensions.DependencyInjection;


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

            services.AddHttpClient<ILemmyService, LemmyService>(client => { client.BaseAddress = uri; })
                .ConfigurePrimaryHttpMessageHandler(() =>
                    new CustomAuthenticationHandler(uri, username, password, retrieveToken, saveToken));


        }

        public static string GetQueryString(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var property in properties)
            {
                var originalValue = property.GetValue(obj);
                if(originalValue == null) continue;
                var nameOverride = property?.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;



                var isNullable = (property?.PropertyType.IsGenericType ?? false) && property?.PropertyType.GetGenericTypeDefinition() == typeof(System.Nullable<>);

                var type = isNullable
                    ? Nullable.GetUnderlyingType(property?.PropertyType)
                    : property?.PropertyType;
                
                var typeCode = Type.GetTypeCode(type); 
                
                
                
                var value = typeCode  switch
                {
                    TypeCode.Empty => string.Empty,
                    TypeCode.Boolean => originalValue.ToString()?.ToLower(),
                    TypeCode.Char =>  originalValue.ToString(),
                    TypeCode.Int16 =>  originalValue.ToString(),
                    TypeCode.UInt16 =>  originalValue.ToString(),
                    TypeCode.Int32 =>  originalValue.ToString(),
                    TypeCode.UInt32 =>  originalValue.ToString(),
                    TypeCode.Int64 =>  originalValue.ToString(),
                    TypeCode.UInt64 =>  originalValue.ToString(),
                    TypeCode.Single =>  originalValue.ToString(),
                    TypeCode.Double =>  originalValue.ToString(),
                    TypeCode.Decimal =>  originalValue.ToString(),
                    TypeCode.String => originalValue.ToString(),
                    TypeCode.DateTime => ((DateTime)originalValue).ToString("h:mm:ss tt zz"),
                    _ => throw new ArgumentOutOfRangeException()
                };

                query[Json.ConvertSnakeCase(nameOverride, "_")] = value;
            }

            return query.ToString();
        }
    }
}