using System.Net.Http;
using System.Text.Json;
using Framework.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;


namespace Framework
{
    [TestFixture]
    public class EpisodesTests : TestBase
    {
        private HttpClient httpClient;
        private string url;

        [SetUp]
        protected void Initialize()
        {
            url = Config.BaseUrl;
            Log.Information("Our endpoint: " + url);
            httpClient = new HttpClient();
        }

        [Test]
        public async Task GetEpisodes()
        {
            Log.Information("Test GetEpisodes was started!");

            url = url + "episodes";
            var response = await httpClient.GetAsync(url);
            Log.Information($"{url}");
            Log.Information("Status code: " + response.StatusCode);
            Log.Information("Response content: " + response.Content);

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var items = root.GetProperty("items");

            var firstEpisode = items[0];

            var name = firstEpisode.GetProperty("name").GetString();
            var number = firstEpisode.GetProperty("number").GetInt32();
            Log.Information("Name: " + name);
            Log.Information("Number: " + number);
        }

        [Test]
        public async Task GetEpisodeId()
        {
            Log.Information("Test GetEpisodeId was started!");
            url = url + "episodes/5";
            var response = await httpClient.GetAsync(url);
            Log.Information($"{url}");
            Log.Information("Status code: " + response.StatusCode);
            Log.Information("Response content: " + response.Content);

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var id = root.GetProperty("id").GetInt32();
            var name = root.GetProperty("name").GetString();
            var duration = root.GetProperty("duration").GetInt32();

            Log.Information("Id: " + id);
            Log.Information("Name: " + name);
            Log.Information("Duration: " + duration);

            Assert.Multiple(() =>
            {
                Assert.That(id, Is.EqualTo(5), "Episode id is not correct!");
                Assert.That(name, Is.EqualTo("Fear of a Bot Planet"), "Episode name is not correct!");
                Assert.That(duration, Is.EqualTo(1800), "Episode duration is not correct!");
            });
        }
    }
}
