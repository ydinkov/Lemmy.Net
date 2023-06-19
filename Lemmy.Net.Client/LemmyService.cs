using System.Reflection;
using Lemmy.Net.Client.Models;
using System.Text;
using System.Text.Json;



namespace Lemmy.Net.Client.Models
{
    public class LemmyService : ILemmyService
    {
        private readonly HttpClient _client;

        public LemmyService(HttpClient client)
        {
            _client = client;
        }

        internal async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync($"/api/v3{endpoint}");

            if (!response.IsSuccessStatusCode)
            {
                
                throw new ApplicationException($"Something went wrong calling the API: {response.StatusCode}");
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        internal async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest content)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(content),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync($"/api/v3{endpoint}", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.StatusCode}");
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<PostEnvelope> DeletePostsAsync(int postId) => 
            await PostAsync<DeletePost,PostEnvelope>($"/post/delete",new (){PostId = postId});

        public async Task<PostEnvelope> CreatePostsAsync(CreatePost post) => 
            await PostAsync<CreatePost,PostEnvelope>($"/post",post);

        public Task<PostEnvelope> GetPostAsync(string postId) => 
            GetAsync<PostEnvelope>($"/post?id={postId}");

        public async Task<PostsEnvelope> GetPostsAsync(string comunityId) =>
            await GetAsync<PostsEnvelope>($"/post/list?community={comunityId}");

        public async Task<CommunityEnvelope> GetCommunitiesAsync() =>
            await GetAsync<CommunityEnvelope>($"/community/list");
    }

    public interface ILemmyService
    {
        Task<PostEnvelope> DeletePostsAsync(int postId);
        Task<PostEnvelope> CreatePostsAsync(CreatePost post);
        
        Task<PostEnvelope> GetPostAsync(string postId);
        Task<PostsEnvelope> GetPostsAsync(string comunityId);
        Task<CommunityEnvelope> GetCommunitiesAsync();
    }
}