using Framework.Helpers;
using NUnit.Framework;
using System.Configuration;

namespace Framework
{
    [TestFixture]
    public class EpisodesTests
    {
        [Test]
        
        public void ConfigurationTest()
        {
            string url = ConfigurationManager.BaseUrl;
            Console.WriteLine("Our endpoint: " + url);
        }
    }
}
