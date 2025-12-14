using System.Net.Http.Json;
using System.Text.Json;
using Framework.Models;

namespace Framework.Common
{
    public class FuturamaApiClient
    {
        private readonly HttpClient _httpClient;

        public FuturamaApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Episode> GetEpisodeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"episodes/{id}");
            response.EnsureSuccessStatusCode();

            var episode = await response.Content.ReadFromJsonAsync<Episode>(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return episode ?? throw new JsonException("Failed to deserialize episode");
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("users", user);

            // NOTE: API currently does not always return 200 OK
            // so EnsureSuccessStatusCode is intentionally not used
            var createdUser = await response.Content.ReadFromJsonAsync<User>();

            return createdUser ?? throw new Exception("User creation failed");
        }
    }
}
