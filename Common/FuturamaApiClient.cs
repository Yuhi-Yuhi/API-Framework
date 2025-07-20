using System.Net.Http.Json;
using System.Text.Json;
using Framework.Models;

namespace Framework.Common
{
    public class FuturamaApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public FuturamaApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public async Task<Episode> GetEpisodeByIdAsync(int id)
        {
            var requestUrl = $"{_baseUrl}/episodes/{id}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var episode = JsonSerializer.Deserialize<Episode>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (episode == null)
            {
                throw new JsonException("Failed to deserialize episode");
            }

            return episode;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var requestUrl = $"{_baseUrl}/users";

            var response = await _httpClient.PostAsJsonAsync(requestUrl, user);
            response.EnsureSuccessStatusCode();

            var createdUser = await response.Content.ReadFromJsonAsync<User>();
            return createdUser ?? throw new Exception("User creation failed");
        }
    }
}
