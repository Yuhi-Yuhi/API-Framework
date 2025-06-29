using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using Framework.Common;
using Framework.Models;
using Framework.TestData;
using NUnit.Framework;
using Serilog;

namespace Framework
{
    [TestFixture]
    public class EpisodesTests : TestBase
    {
        private HttpClient httpClient;
        private FuturamaApiClient apiClient;
        private string url;

        [SetUp]
        protected void Initialize()
        {
            url = Config.BaseUrl;
            Log.Information("Our endpoint: " + url);
            httpClient = new HttpClient();
            apiClient = new FuturamaApiClient(url);
        }

        [Test]
        [Explicit("Test should be executed only localy from VS.")]
        public async Task GetEpisodes() // переделать !
        {
            Log.Information("Test GetEpisodes was started!");

            url = $"{url}/episodes";
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

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(151)]
        public async Task GetEpisodeIdNegativeCases(int episodeId)
        {
            url = $"{url}/episodes/{episodeId}";
            var response = await httpClient.GetAsync(url);

            Log.Information($"Request URL: {url}");
            Log.Information($"Status code: {response.StatusCode}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was incorrect!");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(70)]
        [TestCase(149)]
        [TestCase(150)]
        public async Task GetEpisodeIdPositiveCases(int episodeId)
        {
            url = $"{url}/episodes/{episodeId}";
            var response = await httpClient.GetAsync(url);

            Log.Information($"Request URL: {url}");
            Log.Information($"Status code: {response.StatusCode}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was incorrect!");
        }

        [TestCase(0, HttpStatusCode.NotFound)]
        [TestCase(1, HttpStatusCode.OK)]
        [TestCase(2, HttpStatusCode.OK)]
        [TestCase(70, HttpStatusCode.OK)]
        [TestCase(149, HttpStatusCode.OK)]
        [TestCase(150, HttpStatusCode.OK)]
        [TestCase(151, HttpStatusCode.NotFound)]

        public async Task GetEpisodeIdBoundaryValuesTest(int episodeId, HttpStatusCode statusCode)
        {
            url = $"{url}/episodes/{episodeId}";
            var response = await httpClient.GetAsync(url);

            Log.Information($"Request URL: {url}");
            Log.Information($"Status code: {response.StatusCode}");

            Assert.That(response.StatusCode, Is.EqualTo(statusCode), "Status code was incorrect!");
        }

        [Test]
        [Ignore("Dublicated test. Should be removed.")]
        public async Task GetEpisodeId()
        {
            Log.Information("Test GetEpisodeId was started!");
            url = $"{url}/episodes/5";
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

        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        [TestCaseSource(typeof(EpisodeTestData), nameof(EpisodeTestData.GetEpisodes))]
        public async Task GetEpisode(Episode expectedEpisode)
        {
            url = $"{url}/episodes/{expectedEpisode.Id}";

            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var actualEpisode = JsonSerializer.Deserialize<Episode>(json);

            Assert.Multiple(() =>
            {
                Assert.That(actualEpisode.Id, Is.EqualTo(expectedEpisode.Id), "Episode id is not correct!");
                Assert.That(actualEpisode.Name, Is.EqualTo(expectedEpisode.Name), "Episode name is not correct!");
                Assert.That(actualEpisode.Number, Is.EqualTo(expectedEpisode.Number), "Episode number is not correct!");
                Assert.That(actualEpisode.ProductionCode, Is.EqualTo(expectedEpisode.ProductionCode), "Episode productioncode is not correct!");
                Assert.That(actualEpisode.AirDate, Is.EqualTo(expectedEpisode.AirDate), "Episode airDate is not correct!");
                Assert.That(actualEpisode.Duration, Is.EqualTo(expectedEpisode.Duration), "Episode duration is not correct!");
                Assert.That(actualEpisode.CreatedAt, Is.EqualTo(expectedEpisode.CreatedAt), "Episode createdAt is not correct!");
                Assert.That(actualEpisode.BroadcastCode, Is.EqualTo(expectedEpisode.BroadcastCode), "Episode broadcastCode is not correct!");
            });
        }

        [Test]
        [TestCaseSource(typeof(EpisodeTestData), nameof(EpisodeTestData.GetEpisodes))]
        public async Task GetEpisode23423423(Episode expectedEpisode)
        {
            var actualEpisode = await apiClient.GetEpisodeByIdAsync(expectedEpisode.Id);

            Assert.Multiple(() =>
            {
                Assert.That(actualEpisode.Id, Is.EqualTo(expectedEpisode.Id), "Episode id is not correct!");
                Assert.That(actualEpisode.Name, Is.EqualTo(expectedEpisode.Name), "Episode name is not correct!");
                Assert.That(actualEpisode.Number, Is.EqualTo(expectedEpisode.Number), "Episode number is not correct!");
            });
        }
    }
}
