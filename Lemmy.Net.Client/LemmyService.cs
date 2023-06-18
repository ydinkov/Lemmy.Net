﻿using Lemmy.Net.Client.Models;
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

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync($"/api/v3/{endpoint}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.StatusCode}");
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest content)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(content),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync($"/api/v3/{endpoint}", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.StatusCode}");
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<PostEnvelope>> GetPostsAsync(string comunityId) =>
            await GetAsync<List<PostEnvelope>>($"/api/v3/post/list?community={comunityId}");

        public async Task<List<PostEnvelope>> GetComunitiesAsync(string comunityId) =>
            await GetAsync<List<PostEnvelope>>($"/api/v3/post/list?community={comunityId}");
    }

    public interface ILemmyService
    {
        Task<T?> GetAsync<T>(string endpoint);
    }
}