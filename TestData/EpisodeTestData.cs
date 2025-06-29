using Framework.Models;
using NUnit.Framework;

namespace Framework.TestData
{
    public static class EpisodeTestData
    {
        public static IEnumerable<TestCaseData> GetEpisodes() 
        {
            yield return new TestCaseData(Episode.GetEpisode1()).SetName("GetEpisode_id_1");
            yield return new TestCaseData(Episode.GetEpisode5()).SetName("GetEpisode_id_5");
            yield return new TestCaseData(Episode.GetEpisode27()).SetName("GetEpisode_id_27");
        }
    }
}
