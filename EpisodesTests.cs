using System.Net.Http;
using System.Text.Json;
using Framework.Models;
using NUnit.Framework;


namespace Framework
{
    [TestFixture]
    public class EpisodesTests
    {
        private HttpClient httpClient;
        private string url;

        [SetUp]
        protected void Initialize()
        {
            url = Config.BaseUrl;
            Console.WriteLine("Our endpoint: " + url);
            httpClient = new HttpClient();
        }

        [Test]
        public async Task GetEpisodes()
        {
            url = url + "episodes";
            var response = await httpClient.GetAsync(url);
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
        public async Task GetEpisodeId()
        {
            url = url + "episodes/5";
            var response = await httpClient.GetAsync(url);
            Console.WriteLine($"{url}");
            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("Response content: " + response.Content);

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var id = root.GetProperty("id").GetInt32();
            var name = root.GetProperty("name").GetString();
            var duration = root.GetProperty("duration").GetInt32();

            Console.WriteLine("Id: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Duration: " + duration);

            Assert.Multiple(() =>
            {
                Assert.That(id, Is.EqualTo(5), "Episode id is not correct!");
                Assert.That(name, Is.EqualTo("Fear of a Bot Planet"), "Episode name is not correct!");
                Assert.That(duration, Is.EqualTo(1800), "Episode duration is not correct!");
            });
        }

        [TearDown]
        protected void Uninitialize()
        {
            Console.WriteLine("Testend");
        }
    }
}
