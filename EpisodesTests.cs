using Framework.Helpers;
using Framework.Models;
using NUnit.Framework;
using System.Configuration;

namespace Framework
{
    [TestFixture]
    public class EpisodesTests
    {
        [SetUp]

        protected void Initialize()
        {
            string url = Config.BaseUrl;
            Console.WriteLine("Our endpoint: " + url);
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
