using Framework.Common;
using Framework.Common.Http;
using Framework.Models;
using Framework.TestData;
using NUnit.Framework;
using Serilog;

namespace Framework.Tests
{
    [TestFixture]
    public class EpisodesTests : TestBase
    {
        private FuturamaApiClient apiClient;

        [SetUp]
        public void Initialize()
        {
            var httpClient = HttpClientProvider.Create();
            apiClient = new FuturamaApiClient(httpClient);

            Log.Information("Running tests against {BaseUrl}", httpClient.BaseAddress);
        }

        [Test]
        [Explicit("Test should be executed only locally from VS.")]
        public async Task GetEpisodes()
        {
            Log.Information("Test GetEpisodes was started!");

            // API не имеет отдельного метода получения списка,
            // поэтому используем HttpClient напрямую ТОЛЬКО здесь
            var httpClient = HttpClientProvider.Create();
            var response = await httpClient.GetAsync("episodes");

            Assert.That(response.IsSuccessStatusCode, Is.True, "Episodes request failed");

            var json = await response.Content.ReadAsStringAsync();

            Log.Information("Status code: {StatusCode}", response.StatusCode);
            Log.Information("Response body: {Body}", json);

            Assert.That(json, Is.Not.Null.And.Not.Empty);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(151)]
        public void GetEpisodeIdNegativeCases(int episodeId)
        {
            var ex = Assert.ThrowsAsync<HttpRequestException>(
                async () => await apiClient.GetEpisodeByIdAsync(episodeId));

            Log.Information("Negative case for episodeId={EpisodeId}. Exception: {Message}", episodeId, ex!.Message);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(70)]
        [TestCase(149)]
        [TestCase(150)]
        public async Task GetEpisodeIdPositiveCases(int episodeId)
        {
            var episode = await apiClient.GetEpisodeByIdAsync(episodeId);

            Assert.Multiple(() =>
            {
                Assert.That(episode, Is.Not.Null);
                Assert.That(episode.Id, Is.EqualTo(episodeId));
            });
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(70, true)]
        [TestCase(149, true)]
        [TestCase(150, true)]
        [TestCase(151, false)]
        public async Task GetEpisodeIdBoundaryValuesTest(int episodeId, bool shouldExist)
        {
            if (shouldExist)
            {
                var episode = await apiClient.GetEpisodeByIdAsync(episodeId);
                Assert.That(episode.Id, Is.EqualTo(episodeId));
            }
            else
            {
                Assert.ThrowsAsync<HttpRequestException>(
                    async () => await apiClient.GetEpisodeByIdAsync(episodeId));
            }
        }

        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        [TestCaseSource(typeof(EpisodeTestData), nameof(EpisodeTestData.GetEpisodes))]
        public async Task GetEpisode(Episode expectedEpisode)
        {
            var actualEpisode = await apiClient.GetEpisodeByIdAsync(expectedEpisode.Id);

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
    }
}