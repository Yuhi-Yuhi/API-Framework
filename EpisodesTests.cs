using System.Text.Json;
using Framework.Models;
using NUnit.Framework;


namespace Framework
{
    [TestFixture]
    public class EpisodesTests
    {
        private HttpClient _httpClient;

        [SetUp]
        protected void Initialize()
        {
            string url = Config.BaseUrl;
            Console.WriteLine("Our endpoint: " + url);
            _httpClient = new HttpClient();
        }

        [Test]
        public async Task GetEpisodes()
        {
            string url = "https://futuramaapi.com/api/episodes";
            var response = await _httpClient.GetAsync(url);
            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("Response content: " + response.Content);

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var items = root.GetProperty("items");

            var firstEpisode = items[0];

            var name = firstEpisode.GetProperty("name").GetString();
            var number = firstEpisode.GetProperty("number").GetInt32();
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Number: " + number);

        }

        [Test]
        public void ConfigurationTest()
        {
            var episode = Episode.GetDefaultEpisode();
            Console.WriteLine(episode.name);
        }

        [Test]
        public void ConfigurationTest2()
        {
            var episode = Episode.GetDefaultEpisode();
            Console.WriteLine(episode.name);
        }

        [TearDown]
        protected void Uninitialize()
        {
            Console.WriteLine("Testend");
        }
    }
}
